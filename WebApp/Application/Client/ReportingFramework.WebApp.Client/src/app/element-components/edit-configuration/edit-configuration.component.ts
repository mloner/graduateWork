import {Component, ElementRef, Inject, Input, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import {
  NewEditComponentRow,
  ParamValueRowModels,
  ComponentModel,
  Type,
  ComponentConfiguration,
  ConfigurationModel,
  ConfigComponentProperty,
  ConfigurationPropertiesComponents,
  ConfigurationPropertyModel,
  EditSaveConfiguration
} from "../../interfaces/MeteData.interfaces";
import {HttpClient} from "@angular/common/http";
import {ApiUrl} from "../../app.module";
import {MatDialog} from "@angular/material/dialog";
import {ConfigurationComponent} from "../../content-components/configuration/configuration.component";
import * as go from "gojs";
import { ActivatedRoute } from '@angular/router';
import JSONFormatter from 'json-formatter-js';
import {decimalDigest} from "@angular/compiler/src/i18n/digest";
import * as moment from "moment";
import * as lodash from "lodash";

@Component({
  selector: 'app-edit-configuration',
  templateUrl: './edit-configuration.component.html',
  styleUrls: ['./edit-configuration.component.css']
})
export class EditConfigurationComponent implements OnInit {
  types!: Type[];
  typesAll!:Type[];
  elem: any;
  public configurationList: ComponentConfiguration[] = [];
  oldId: any;
  oldTypeId: any = -1;
  oldComponent: any;
  currentComponent: any;
  item: any;
  countElem:number = 1;
  busyType:any = [];
  configuration: any;

  elements: any = [];
  topology: any = {};
  jsonConf: any = {"topology": {}, "elements": []};
  jsonConfStr: any;
  elemJson: any;
  jsonConfTwo: any;
  formatter: any;

  propertyComponent: ConfigurationPropertiesComponents = {configurationPropertyComponentId: -1, configurationComponentId: 0, configurationPropertyId: 0, value: "1"};
  configComponentProperty: ConfigComponentProperty = {configurationPropertiesComponents: [], properties: []}
  configProperty: ConfigComponentProperty[] = [];

  arrayForJson: EditSaveConfiguration = {componentConfigurations: [], configurationPropertiesComponents: []};

  diagramConf: any = [];
  $:any = go.GraphObject.make;
  model:any = this.$(go.TreeModel);
  myDiagram:any;
  lvl:number = 0;

  configurationInput: any;
  configurationId: any;
  config: any;
  @ViewChild('listConfig') listConfig!: ElementRef;
  @ViewChild('json') jsonVal!: ElementRef;

  constructor(private http: HttpClient,  @Inject(ApiUrl) private apiUrl: string, public dialog: MatDialog, private route: ActivatedRoute) {
    debugger
    this.route.queryParams.subscribe(params => {
      debugger
      this.configurationId = Number(params.configurationId);
    });

    /*this.http.get<any>(this.apiUrl + '/configuration/componentForConfig/configurattttId=' + this.configurationId, {responseType: "blob" as "json"}).subscribe(result=> {
      debugger
      // this.configurationList = result;
      // for (var i=0; i< this.configurationList.length; i++){
      //   this.configurationList[i].parents = this.configurationList.slice(0,i);
      // }
      // this.countElem = Math.floor(this.listConfig.nativeElement.offsetWidth/320);//кол-во, блоков на странице
      // this.convertToJson();
      // this.initDiagram();
      // this.setDiagram();

      var reader = new FileReader();
      reader.addEventListener('loadend', (e) => {
        var res = e.target?.result;
        this.getBlob(res);
      });
      reader.readAsText(result);
    }, error => {
      console.log(error);
    })*/

  }

  ngOnInit(): void {
    debugger
    this.http.get<any>(this.apiUrl + '/configuration/' + this.configurationId).subscribe(result=> {
      debugger
      this.configuration = result;
    }, error => {
      console.log(error);
    })
    this.http.get<any>(this.apiUrl + '/components/types/notNullComponents').subscribe(result=> {
      debugger
      this.types = result;
    }, error => {
      console.log(error);
    })
    debugger
    this.http.get<Type[]>(this.apiUrl + '/components/typesAll').subscribe(result=> {
      debugger
      this.typesAll = result;
    }, error => {
      console.log(error);
    })

    debugger
    this.http.get<ConfigComponentProperty[]>(this.apiUrl + '/configuration/configComponentProperty/configurationId=' + this.configurationId).subscribe(result=> {
      debugger
      this.configProperty = result;
    }, error => {
      console.log(error);
    })

    this.http.post<any>(this.apiUrl + '/configuration/componentForConfig/configId=' + this.configurationId, "").subscribe(result=> {
      debugger
      this.configurationInput = result;
      this.configurationList = this.configurationInput;
      // for (var i=0; i< this.configurationList.length; i++){
      //   if (this.configurationList[i].componentsByType.find(q=>q.componentId == this.configurationList[i].componentId)?.notDeleted == false){
      //     this.configurationList = this.configurationList.splice(i,i);
      //   }
      // }
      for (var i=0; i< this.configurationList.length; i++){
        this.configurationList[i].parents = this.configurationList.slice(0,i);
      }
      this.countElem = Math.floor(this.listConfig.nativeElement.offsetWidth/320);//кол-во, блоков на странице
      this.convertToJson();
      this.initDiagram();
      this.setDiagram();
    }, error => {
      console.log(error);
    })
  }

  getBlob(reader: any) {
    debugger
    this.configurationInput = JSON.parse(reader);
    for (var i=0 ; i <= this.configurationInput.length; i++){
      this.configurationList.push(this.configurationInput[i]);
    }
    for (var i=0; i< this.configurationList.length; i++){
      this.configurationList[i].parents = this.configurationList.slice(0,i);
    }
    this.countElem = Math.floor(this.listConfig.nativeElement.offsetWidth/320);//кол-во, блоков на странице
    alert(this.configurationList[0].componentTypeId);
    this.convertToJson();
    this.initDiagram();
    this.setDiagram();
  }

  getComponentTypes(typeId: number, conf_index: number): void {
    this.http.get<ComponentModel[]>(this.apiUrl + '/components/type=' + typeId).subscribe(result => {
      debugger
      // делаем проверку на наличие удаленного типа
      if (this.configurationList[conf_index].types.findIndex(q=>!q.notDeleted) != -1){
        // удалим из выбора этот тип
        this.configurationList[conf_index].types.splice(this.configurationList[conf_index].types.findIndex(q=>!q.notDeleted),1);
      }

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
    return parent.types.find((z: { componentTypeId: any; })=>z.componentTypeId == comp.componentTypeId).name + ": " +
      parent.componentsByType.find((q: { componentId: any; })=>Number(q.componentId) == Number(parent.componentId)).name;
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
      this.changeElements(conf_index);
    }, error => {
      console.log(error);
    })
  }

  changeElements(conf_index: number){
    debugger
    // делаем проверку на наличие удаленного компонента
    if (this.configurationList[conf_index].componentsByType.findIndex(q=>!q.notDeleted) != -1){
      // удалим из выбора этот компонент
      this.configurationList[conf_index].componentsByType.splice(this.configurationList[conf_index].componentsByType.findIndex(q=>!q.notDeleted),1);
    }
    this.convertToJson();
    this.setDiagram();
  }

  deleteConf(conf_index:number){
    // удалить из всех parents у элементов, идущих после удаляемого
    for (var i = conf_index+1; i < this.configurationList.length; i ++){
      debugger
      this.configurationList[i].parents.splice(conf_index,1);
    }
    // удалим элемент из списка конфигурации
    this.configurationList.splice(conf_index, 1);
    // удалим массив свойств элемента
    this.configProperty.splice(conf_index,1);
    //обновим json
    this.convertToJson();
    //обновим диаграмму
    this.setDiagram();
  }


  clickPlus(){
    debugger
    this.oldTypeId=-1;
    // создадим новый элемент
    this.elem = {};
    // массив состоит из типов с HaveParent = true и эти типы не содержатся в busyType
    this.elem.types = this.types.filter(q=>q.haveParent).filter((q: any)=>this.busyType.indexOf(q.componentTypeId) == -1);
    this.elem.componentTypeId = this.elem.types[0].componentTypeId;
    this.elem.componentId = -1;
    this.elem.componentsByType = [];
    // добавим в общий список
    this.configurationList.push(this.elem);
    // инициализируем массив свойств для нового компонента
    this.configProperty.push(lodash.cloneDeep(this.configComponentProperty));
    // внесем данные
    this.getComponentTypes(Number(this.configurationList[this.configurationList.length-1].componentTypeId), this.configurationList.length-1);
  }

  convertToJson(){
    debugger
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
  }

  beautifyJsonString() {
    try {
      return JSON.stringify(this.jsonConf, null, 4);
    } catch (e) {}
    return "";
  }

  getJson(){
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
    link.download = this.configuration.name + " " + date + ".json";
    link.click();
    window.URL.revokeObjectURL(url);
    link.remove();
  }

  initDiagram(){
    this.myDiagram =
      this.$(go.Diagram, "myDiagramDiv_edit_" + this.configurationId,
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
      this.diagramConf.push(
        {
          key:i,
          parent: Number(this.configurationList[i].parentId) != -1 ? Number(this.configurationList[i].parentId) : "",
          name: this.configurationList[i].types.find(q=>q.componentTypeId == this.configurationList[i].componentTypeId)?.name + ": " +
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

  getDate(dateTime: any){
    return moment(dateTime).format("DD.MM.YYYY HH:mm:ss");
  }
}
