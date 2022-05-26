import {Component, ElementRef, Inject, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import {
  NewEditComponentRow,
  ParamValueRowModels,
  ComponentModel,
  Type,
  ComponentConfiguration,
  ConfigComponentProperty,
  ConfigurationPropertyModel,
  ConfigurationPropertiesComponents, EditSaveConfiguration
} from "../../interfaces/MeteData.interfaces";
import {HttpClient} from "@angular/common/http";
import {ApiUrl} from "../../app.module";
import {MatDialog} from "@angular/material/dialog";
import {ConfigurationComponent} from "../../content-components/configuration/configuration.component";
import * as go from "gojs";
import JSONFormatter from "json-formatter-js";
import * as moment from "moment";
import * as lodash from "lodash";

@Component({
  selector: 'app-new-configuration',
  templateUrl: './new-configuration.component.html',
  styleUrls: ['./new-configuration.component.css'],
})
export class NewConfigurationComponent implements OnInit {
  types!: Type[];
  elem: any;
  configurationList: ComponentConfiguration[] = [];
  oldId: any;
  oldTypeId: any = -1;
  oldComponent: any;
  currentComponent: any;
  item: any;
  @ViewChild('listConfig') listConfig!: ElementRef;
  @ViewChild('jsonNew') jsonVal!: ElementRef;
  countElem:number = 1;
  busyType:any = [];
  typesAll!:Type[];

  propertyComponent: ConfigurationPropertiesComponents = {configurationPropertyComponentId: -1, configurationComponentId: 0, configurationPropertyId: 0, value: "1"};
  configComponentProperty: ConfigComponentProperty = {configurationPropertiesComponents: [], properties: []}
  configProperty: ConfigComponentProperty[] = [];

  elements: any = [];
  topology: any = {};
  jsonConf: any = {"topology": {}, "elements": []};
  elemJson: any;
  formatter: any;
  arrayForJson: EditSaveConfiguration = {componentConfigurations: [], configurationPropertiesComponents: []};

  diagramConf: any = [];
  $:any = go.GraphObject.make;
  model:any = this.$(go.TreeModel);
  myDiagram:any;
  lvl:number = 0;

  constructor(private http: HttpClient,  @Inject(ApiUrl) private apiUrl: string, public dialog: MatDialog) {
    this.http.get<any>(this.apiUrl + '/components/types/notNullComponents').subscribe(result=> {
      debugger
      this.countElem = Math.floor(this.listConfig.nativeElement.offsetWidth/320);//кол-во, блоков на странице
      this.types = result;
      this.elem = {};
      this.elem.types = result;
      this.elem.componentTypeId = result[0].componentTypeId;
      this.configurationList.push(this.elem);
      this.configProperty.push(lodash.cloneDeep(this.configComponentProperty));
      this.initDiagram();
      this.getComponentTypes(Number(this.configurationList[0].componentTypeId), 0);
    }, error => {
      console.log(error);
    })
  }

  ngOnInit(): void {
    this.http.get<any>(this.apiUrl + '/components/typesAll').subscribe(result=> {
      this.typesAll=result;
    }, error => {
      console.log(error);
    })
  }

  getComponentTypes(typeId: number, conf_index: number): void {
    debugger
    this.http.get<ComponentModel[]>(this.apiUrl + '/components/type=' + typeId).subscribe(result => {
      debugger
      // меняем возможность выбора component
      this.configurationList[conf_index].componentsByType = result;
      // присваиваем componentId первое значение из списка components или -2, если список пуст
      this.configurationList[conf_index].componentId = this.configurationList[conf_index].componentsByType.length != 0 ? this.configurationList[conf_index].componentsByType[0].componentId : -2;

      // родителями могут быть все выбранные элементы до текущего
      this.configurationList[conf_index].parents = this.configurationList.slice(0,conf_index);
      // назнаим parent первый элемент в конфигурации - его индекс (0)
      this.configurationList[conf_index].parentId = this.configurationList[conf_index].parents.length > 0 ? 0 : -1;

      this.getConfigProperty(typeId, conf_index);
    }, error => {
      console.log(error);
    })
  }


  getNameParent(parent: any, types: any): string {
    var comp = parent.componentsByType.find((q: { componentId: any; })=>Number(q.componentId) == Number(parent.componentId));
    return types.find((z: { componentTypeId: any; })=>z.componentTypeId == comp.componentTypeId).name + ": " +
      parent.componentsByType.find((q: { componentId: any; })=>Number(q.componentId) == Number(parent.componentId)).name;
  }

  changeElements(){
    this.convertToJson();
    this.setDiagram();
  }

  getConfigProperty(typeId: number, conf_index: number) {
    debugger
    this.http.get<ConfigurationPropertyModel[]>(this.apiUrl + '/configuration/configurationProperty/componentTypeId=' + typeId).subscribe(result => {
      debugger
      this.configProperty[conf_index].properties = result;
      for (var i=0; i<this.configProperty[conf_index].properties.length; i++){
        this.configProperty[conf_index].configurationPropertiesComponents[i] = lodash.cloneDeep(this.propertyComponent);
        this.configProperty[conf_index].configurationPropertiesComponents[i].configurationComponentId = this.configurationList[conf_index].componentId;
        this.configProperty[conf_index].configurationPropertiesComponents[i].configurationPropertyId = this.configProperty[conf_index].properties[i].configurationPropertyId;
      }
      this.changeElements();
    }, error => {
      console.log(error);
    })
  }

  deleteConf(conf_index:number){
    // удалить из всех parents у элементов, идущих после удаляемого
    for (var i = conf_index+1; i < this.configurationList.length; i ++){
      this.configurationList[i].parents.splice(conf_index,1);
      if (Number(this.configurationList[i].parentId) == Number(conf_index)){
        this.configurationList[i].parentId = 0;
      }
    }

    // удалим элемент из списка конфигурации
    this.configurationList.splice(conf_index, 1);
    // удалим массив свойств элемента
    this.configProperty.splice(conf_index,1);
    //обновим json
    this.convertToJson();
    debugger
    //обновим диаграмму
    this.setDiagram();
  }


  clickPlus(){
    debugger
    this.oldTypeId = -1;
    // создадим новый элемент
    this.elem = {};
    // массив состоит из типов с HaveParent = true и эти типы не содержатся в busyType
    this.elem.types = this.types.filter(q=>q.haveParent).filter((q: any)=>this.busyType.indexOf(q.componentTypeId) == -1);
    this.elem.componentTypeId = this.elem.types[0].componentTypeId;
    this.elem.componentId = -1;
    // добавим в общий список
    this.configurationList.push(this.elem);
    // инициализируем массив свойств для нового компонента
    this.configProperty.push(lodash.cloneDeep(this.configComponentProperty));
    // внесем данные
    this.getComponentTypes(Number(this.configurationList[this.configurationList.length-1].componentTypeId), this.configurationList.length-1);
  }

  convertToJson(){
    debugger
    this.arrayForJson.componentConfigurations = this.configurationList;
    this.arrayForJson.configurationPropertiesComponents = this.configProperty.map(q=>q.configurationPropertiesComponents);
    this.http.post<object>(this.apiUrl + '/configuration/json/configurationList', this.arrayForJson).subscribe(result=> {
      debugger
      this.jsonConf = result;
      this.getJson();
    }, error => {
      console.log(error);
    });

    /*this.http.post<NewEditComponentRow[]>(this.apiUrl + '/configuration/newEditComponentArray', this.configurationList).subscribe(result=> {
      debugger
      // сформирем elements для json представления
      this.elements = [];
      for (var i=0;i<result.length; i++){
        this.elements[i] = {};
        this.elements[i]["componentId"] = result[i].componentId;
        this.elements[i]["name"] = result[i].componentName;
        this.elements[i]["componentType"] = this.types.find(q=>q.componentTypeId==result[i].componentTypeId)?.name;
        if (this.elements[i]["componentType"].indexOf("Grid") != -1){
          this.elements[i]["dateTime"] = this.getDate(result[i].dateTime);
        }
        this.elements[i]["parameters"] = result[i].paramValueRowModels.filter(q=>q.validity);
      }
      this.jsonConf["elements"] = this.elements;

      this.http.post<object>(this.apiUrl + '/configuration/json/topology', this.configurationList).subscribe(result=> {
        debugger
        this.topology = result;
        this.jsonConf["topology"] = this.topology;
        this.getJson();
      }, error => {
        console.log(error);
      });

    }, error => {
      console.log(error);
    });*/
  }

  getJson(){
    debugger
    const config = {
      hoverPreviewEnabled: true,
      hoverPreviewArrayCount: 1,
      hoverPreviewFieldCount: 1,
      theme: "",
      animateOpen: true,
      animateClose: true,
      useToJSON: true
    };

    this.formatter = new JSONFormatter(this.jsonConf, 3, config);
    this.jsonVal.nativeElement.innerHTML = "";
    this.jsonVal.nativeElement.appendChild(this.formatter.render());
  }

  downloadJsonFile(){
    debugger
    const date = moment().format('YY-MM-DD HH-mm-ss');
    const blob = new Blob([this.beautifyJsonString()],{type: 'text/json'});
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    document.body.appendChild(link);
    link.setAttribute('style', 'display: none');
    link.href = url;
    link.download = "Json " + date + ".json";
    link.click();
    window.URL.revokeObjectURL(url);
    link.remove();
  }

  initDiagram(){
    debugger
    this.myDiagram =
      this.$(go.Diagram, "myDiagramDiv",
        {
          allowCopy: false, //нельзя копировать объекты из диаграммы
          allowDelete: false, //нельзя удалять объекты из диаграммы
          allowClipboard: false, //нельзя копировать или вставлять части из внутреннего буфера обмена
          allowInsert: false, //нельзя добавлять объекты на диаграмму
          allowGroup: false, //нельзя группировать объекты на диаграмме
          // allowDrag: false,
          allowLink: false, //нельзя создавать новые ссылки объекты из диаграммы
          allowTextEdit: false, //нельзя редактировать текст в диаграмме
          allowRelink: false, //нельзя повторно подключать существующие ссылки в диаграмме
          "undoManager.isEnabled": true, // enable Ctrl-Z to undo and Ctrl-Y to redo
          "commandHandler.copiesTree": false,
          "commandHandler.deletesTree": false,
          layout: this.$(go.TreeLayout,
            { angle: 90, layerSpacing: 35},
            ),
        });

    // связь NodeDataArray и структур
    this.myDiagram.nodeTemplate =
      this.$(go.Node, "Auto",
        this.$(go.Shape, "RoundedRectangle", // прям со скр углами
          {
            stroke: "#fefefe",
            strokeWidth: 2,
            portId: "",
            cursor: "pointer",
          },
          new go.Binding("fill", "color")),
        this.$(go.TextBlock, "Not found",
          { margin: 12, stroke: "#12406b", font: "18px sans-serif" },
          new go.Binding("text", "name"))
      );

    // стрелки и связи
    this.myDiagram.linkTemplate =
      this.$(go.Link,
        { routing: go.Link.Orthogonal, corner: 5 },
        this.$(go.Shape, { strokeWidth: 2, stroke: "#555" }), //путь
        this.$(go.Shape, { toArrow: "Standard", stroke: null })); //стрелка

  }


  setDiagram(){
    debugger
    // связь NodeDataArray и структур
    this.myDiagram.nodeTemplate =
      this.$(go.Node, "Auto",
        this.$(go.Shape, "RoundedRectangle", // прям со скр углами
          {
            stroke: "#fefefe",
            strokeWidth: 2,
            portId: "",
            cursor: "pointer",
          },
          new go.Binding("fill", "color")),
        this.$(go.TextBlock, "Not found",
          { margin: 12, stroke: "#12406b", font: "12px sans-serif" },
          new go.Binding("text", "name"))
      );

    // стрелки и связи
    this.myDiagram.linkTemplate =
      this.$(go.Link,
        { routing: go.Link.Orthogonal, corner: 5 },
        this.$(go.Shape, { strokeWidth: 2, stroke: "#555" }), //путь
        this.$(go.Shape, { toArrow: "Standard", stroke: null })); //стрелка

    var color = [
      "#82CAFA","#98FB98","#66CDAA","#81D8D0",
      "#FFC0CB","#FFDEAD","#deb887","#C3FDB8",
      "#d8bfd8","#E6E6FA","#F5F5DC","#AFEEEE",
      "#F5FFFA","#FFDAB9","#EEE8AA","#F0E68C",
      "#D2B48C","#BC8F8F","#F4A460","#8FBC8F",
      "#008B8B","#AFEEEE","#5F9EA0","#4682B4",
      "#B0C4DE","#87CEEB","#6495ED","#D8BFD8",
      "#44a185", "#F9D2C0", "#a38812","#7D7B86",
      "#267d7d", "#A29204", "#3d96ec","#a34acb",
      "#F4717C", "#9BB2A1", "#a56f4b","#B8CBFB",
      "#216822", "#058E9E", "#826573","#FEA912",
      "#C08040", "#47bd5a", "#c686db", "#f6ca7b",
      "#724cbd", "#bb6536", "#3aa760", "#4080C0",
      "#fc7bbb", "#80C040", "#6060d5", "#C04040",
      "#4e924e", "#2279ac", "#a05959","#36b360",
      "#68d9e7", "#af444f", "#676E58", "#db979a",
      "#E3FEBC", "#9b74cb", "#A9937C", "#926455",
      "#dec0de", "#03669E", "#B579A0", "#f1c950",
      "#0BB687", "#cb4eae", "#D8C37C", "#FE966F",
      "#d2d95c", "#A0F8ED", "#9D6B06", "#63760A"];

    this.diagramConf = [];
    for (var i=0; i<this.configurationList.length;i++){
      debugger
      this.diagramConf.push(
        {
          key:i,
          parent: Number(this.configurationList[i].parentId) != -1 ? Number(this.configurationList[i].parentId) : "",
          name: this.configurationList[i].types.find(q=>q.componentTypeId == Number(this.configurationList[i].componentTypeId))?.name + ": " +
            this.configurationList[i].componentsByType.find(q=>Number(q.componentId) == Number(this.configurationList[i].componentId))?.name,
          color: color[this.typesAll.findIndex(q=>Number(q.componentTypeId) == Number(this.configurationList[i].componentTypeId))]
        }
      );
    }
    this.model.nodeDataArray = this.diagramConf;
    this.myDiagram.model = this.model;
  }

  getLvl(conf_index: number){
    debugger
    if (Number(this.configurationList[conf_index].parentId) != -1) {
      this.lvl++;
      this.getLvl(this.configurationList.findIndex(q=>Number(q.componentId) == Number(this.configurationList[conf_index].parentId)));
    }
  }
  beautifyJsonString() {
    try {
       return JSON.stringify(this.jsonConf, null, 4);
    } catch (e) {}
    return "";
  }

  getDate(dateTime: any){
    return moment(dateTime).format("DD.MM.YYYY HH:mm:ss");
  }

}
