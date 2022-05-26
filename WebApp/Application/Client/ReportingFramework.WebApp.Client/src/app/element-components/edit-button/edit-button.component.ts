import {Component, ElementRef, EventEmitter, Inject, Input, OnInit, Output, ViewChild} from '@angular/core';
import {
  Building,
  ComponentModel,
  Cug, Measurement,
  NewEditComponentRow,
  ParamValueRowModels
} from "../../interfaces/MeteData.interfaces";
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";
import * as moment from "moment";
import * as lodash from "lodash";

@Component({
  selector: 'app-edit-button',
  templateUrl: './edit-button.component.html',
  styleUrls: ['./edit-button.component.css']
})
export class EditButtonComponent implements OnInit {
  formModal: any;
  status: any;
  @Input() public types: any;
  @Input() public component:any;
  @Input() public valid: any;
  @Output() public editComponent = new EventEmitter();

  public notValid: any = false;
  public notValidNum: any = 0;

  dateOut: any;
  file: any;

  public paramValueRowArray!: ParamValueRowModels[];
  public newEditComponent: NewEditComponentRow = {
    componentId:0,
    componentName:"",
    componentTypeId:0,
    dateTime: "",
    paramValueRowModels:this.paramValueRowArray
  };

  categories: any = [{name:"Specification",key:"S"},{name:"EcoSCADA",key:"E"},{name:"File",key:"F"}];
  selectedCategory: any = this.categories[0];
  guid: any = "";
  editGuid: any = false;
  selectedCug: any;
  selectedBuild: any;
  selectedMeasure: any;
  cugs: Cug[] = [];
  buildings: Building[] = [];
  measurements: Measurement[] = [];
  typeDemand: any = false;
  paramPr: any = "";
  haveProperties: any = false;
  haveGuid: any = false;
  threeMode: any = false;

  fileName: any = "";
  loadingImage: any = false;
  loadSuccess: any = false;
  loadError: any = false;
  @ViewChild('fileUploadEditComp') fileUpload!: ElementRef;

  constructor(@Inject(ApiUrl) private apiUrl: string, private http: HttpClient) {

  }

  ngOnInit(): void {

  }


  // Modal Close
  closeModal(event:any) {
    event.preventDefault();
    event.stopPropagation();
    if(event.target.classList.contains("modal")) {
      this.formModal = false;
    }
  }

  getValue(){
    this.newEditComponent = lodash.cloneDeep(this.component);
    this.dateOut = this.getDate(this.newEditComponent.dateTime);
    this.notValidNum = this.newEditComponent.paramValueRowModels.filter(q=>!q.validity).length;
    this.initBlock();
  }

  getParam(type: number){
    this.http.get<ParamValueRowModels[]>(this.apiUrl + '/components/parameters/type=' + Number(type)).subscribe(result=> {
      debugger
      this.newEditComponent.componentTypeId = Number(type);
      this.newEditComponent.paramValueRowModels = result;
      this.notValidNum = this.newEditComponent.paramValueRowModels.filter(q=>!q.validity).length;

      this.initBlock();
    }, error => {
      console.log(error);
    });
  }

  save(){
    this.preparationData();
    debugger
    this.http.put<ComponentModel>(this.apiUrl + '/components/update', this.newEditComponent).subscribe(result=> {
      this.newEditComponent.dateTime = result.dateAdded;
      this.status = "Component changed."
      alert(this.status);
      if(this.selectedCategory == this.categories[2] && this.file){
        this.createPropertiesFromFile(result.componentId);
      }
      else {
        this.formModal = false;
        this.editComponent.emit(this.newEditComponent);
      }
    }, error => {
      this.status = "Error! Failed to change component."
      alert(this.status);

      console.log(error);
    });
  }

  hasGrid(){
    return this.types.filter((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId)[0]?.name.indexOf("Grid") != -1;
  }

  paramsHaveGuid(){
    return this.newEditComponent.paramValueRowModels.map(q=>q.componentParameterName).indexOf("Guid") != -1;
  }

  getDate(dateTime: any){
    return moment(dateTime).format("DD.MM.YYYY HH:mm:ss");
  }

  oldComponent():any{
    debugger
    this.newEditComponent = this.component;
  }

  preparationData(){
    debugger
    // если выбрана категория Specification
    if (this.selectedCategory == this.categories[0]){
      // обнулим Guid
      this.getGuid("");
      // удалим свойства компонента
      this.removeProperties();
    }
    // если выбрана категория EcoSCADA
    else if (this.selectedCategory == this.categories[1]){
      // обнулим параметры (кроме Guid)
      for (var i = 0; i < this.newEditComponent.paramValueRowModels.length; i++){
        if (this.newEditComponent.paramValueRowModels[i].componentParameterName != "Guid")
          this.newEditComponent.paramValueRowModels[i].value = "";
      }
      // удалим свойства компонента
      this.removeProperties();
    }
    // если выбрана категория File
    else {
      // обнулим и параметры и Guid
      this.getGuid("");
      for (var i = 0; i < this.newEditComponent.paramValueRowModels.length; i++){
        this.newEditComponent.paramValueRowModels[i].value = "";
      }
      // если у компонента есть properties и файл выбран - удалим их
      if (this.haveProperties && this.file){
        this.removeProperties();
      }
    }
  }

  initBlock(){
    debugger
    var tDemand = this.types.find((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId)?.name.indexOf("Demand") != -1;
    var tPV = this.types.find((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId)?.name.indexOf("PV") != -1;
    var tDAM = this.types.find((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId)?.name.indexOf("DAM") != -1;
    this.threeMode = tDemand || tPV || tDAM;
    this.fileName = "";
    this.loadingImage = false;
    this.loadError = false;
    this.loadSuccess = false;
    this.guid = this.newEditComponent.paramValueRowModels.find(q=>q.componentParameterName == "Guid")?.value;
    this.haveGuid = this.guid != null && this.guid != "" && this.guid != undefined;
    this.getCategory();
  }

  getCategory(){
    this.http.get<boolean>(this.apiUrl + '/components/property/have/componentId=' + this.newEditComponent.componentId).subscribe(result=> {
      debugger
      this.haveProperties = result;
      if (this.haveProperties) this.selectedCategory = this.categories[2];
      else if (this.guid && this.guid != "") this.selectedCategory = this.categories[1];
      else this.selectedCategory = this.categories[0];
    }, error => {
      console.log(error);
    });
  }


  getCugs(){
    debugger
    this.http.get<any>(this.apiUrl + '/es/cugs').subscribe(result=> {
      debugger
      this.cugs = result;
      this.selectedCug = result[0].guid;
      this.getBuildings(this.selectedCug);
    }, error => {
      console.log(error);
    });
  }

  getBuildings(selectCug: any){
    debugger
    this.http.get<any>(this.apiUrl + '/es/buildings/cugGuid=' + selectCug).subscribe(result=> {
      debugger
      this.buildings = result;
      if (this.buildings.length > 0){
        this.selectedBuild = result[0].guid;
        this.getMeasurements(this.selectedBuild);
      }
      else {
        this.selectedBuild = -1;
        this.measurements = [];
        this.selectedMeasure = -1;
        this.getGuid("");
      }
    }, error => {
      console.log(error);
    });
  }

  getMeasurements(selectBuild: any){
    debugger
    this.http.get<any>(this.apiUrl + '/es/measurements/buildingGuid=' + selectBuild).subscribe(result=> {
      debugger
      this.measurements = result;
      this.selectedMeasure = result[0].guid;
      this.getGuid(this.selectedMeasure);
    }, error => {
      console.log(error);
    });
  }

  getGuid(guid:any){
    this.paramPr = this.newEditComponent.paramValueRowModels.find(q=>q.componentParameterName == "Guid");
    if (this.paramPr){
      this.paramPr.value = guid;
    }
    this.guid = guid;
  }

  onFileSelected(event:any){
    debugger
    this.file = event.target.files[0];
    if (this.file){
      this.fileName = this.file.name;
    }
    else {
      this.fileName = "";
    }
  }

  createPropertiesFromFile(componentId: any){
    debugger
    if (this.file){
      this.loadingImage = true;
      const date = moment().format('YY-MM-DD HH-mm-ss');
      const formData = new FormData();
      formData.append("file", this.file)
      this.http.post(this.apiUrl + "/files/upload/property/componentId=" + componentId + "&date=" + date, formData).subscribe(result => {
        this.loadingImage = false;
        alert("File data saved successfully!");
        this.removeFile("CreateProperties " + date, "csv");
        this.formModal = false;
        this.editComponent.emit(this.newEditComponent);
      }, error => {
        this.loadingImage = false;
        this.fileName = "";
        this.fileUpload.nativeElement.target.value = "";
        alert("Failed to save data from file.");
        this.removeFile("CreateProperties " + date, "csv");
        console.log(error);
      });
    }
  }

  removeFile(fileName:string, format:string){
    this.http.delete<any>(this.apiUrl + '/files/remove/fileName=' + fileName + "&format=" + format).subscribe(result => {
      var a = result;
    }, error => {
      console.log(error);
    })
  }

  clickFile($event: any){
    debugger
    //$event.preventDefault();
    //$event.stopImmediatePropagation();
    this.fileUpload.nativeElement.click();
  }

  clickEditGuid(){
    this.editGuid = true;
    this.haveGuid = true;
    this.getCugs();
  }

  clickRadio(){
    if (this.selectedCategory == this.categories[1]){
      if (!this.paramsHaveGuid()){
        alert("This type does not have a parameter named 'Guid'. Please add the specified parameter to enable this feature.");
        this.selectedCategory = this.categories[0];
      }
    }
  }

  removeProperties() {
    this.http.delete<any>(this.apiUrl + '/components/property/remove/componentId=' + this.newEditComponent.componentId).subscribe(result=> {
      debugger
      var res = result;
    }, error => {
      console.log(error);
    });
  }
}


