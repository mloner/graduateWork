import {Component, Inject, Input, OnInit, Output, EventEmitter, ViewChild, ElementRef} from '@angular/core';
import {
  Building,
  ComponentModel, Cug, Measurement,
  NewEditComponentCreate,
  ParamValueRowModels
} from "../../interfaces/MeteData.interfaces";
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";
import * as moment from "moment";

@Component({
  selector: 'app-add-button',
  templateUrl: './add-button.component.html',
  styleUrls: ['./add-button.component.css']
})
export class AddButtonComponent implements OnInit {
  formModal: any;
  status: any;
  @Input() public typeId: any;
  @Input() public types: any;
  @Input() public valid: any;
  @Output() public addedComponent = new EventEmitter();

  public notValid: any = false;
  public notValidNum: any = 0;

  file: any;

  public param: ParamValueRowModels = {componentParameterId: 0, componentParameterName: "", pythonParam: "", unit: "",
    desctiption: "", componentValueId: 0, valueTypeId: 0, validity: true};
  public paramValueRowArray: ParamValueRowModels[] = [this.param];
  public newEditComponent: NewEditComponentCreate = {
    componentId:0,
    componentName:"Name",
    componentTypeId:0,
    dateTime: new Date(),
    paramValueRowModels:this.paramValueRowArray
  };

  categories: any = [{name:"Specification",key:"S"},{name:"EcoSCADA",key:"E"},{name:"File",key:"F"}];
  selectedCategory: any = this.categories[0];
  selectedCug: any;
  selectedBuild: any;
  selectedMeasure: any;
  cugs: Cug[] = [];
  buildings: Building[] = [];
  measurements: Measurement[] = [];
  threeMode: any = false;
  paramPr: any = "";
  guid: any = "";

  fileName: any = "";
  loadingImage: any = false;
  loadSuccess: any = false;
  loadError: any = false;
  @ViewChild('fileUploadNewComp') fileUpload!: ElementRef;
  @ViewChild('E') categoryE!: ElementRef;

  constructor(@Inject(ApiUrl) private apiUrl: string, private http: HttpClient) { }

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

  getParamName(type: number){
    this.newEditComponent.componentName = "Name";
    this.getParam(type);
  }

  getParam(type: number){
    this.http.get<ParamValueRowModels[]>(this.apiUrl + '/components/parameters/type=' + Number(type)).subscribe(result=> {
      this.newEditComponent.componentTypeId = Number(type);
      this.newEditComponent.paramValueRowModels = result;
      this.notValidNum = this.newEditComponent.paramValueRowModels.filter(q=>!q.validity).length;

      this.initBlock();
    }, error => {
      console.log(error);
    });
  }

  add(){
    this.preparationData();
    debugger
    this.http.post<ComponentModel>(this.apiUrl + '/components/newComponent', this.newEditComponent).subscribe(result=> {
      debugger
      this.status = "Component created successfully.";
      alert(this.status);
      this.newEditComponent.componentId = result.componentId;
      if (this.selectedCategory == this.categories[2]){
        this.createPropertiesFromFile(result.componentId);
      }
      else {
        this.formModal = false;
        this.addedComponent.emit({"component":result,"newEditRow":this.newEditComponent});
      }

    }, error => {
      this.status = "Error! Failed to create component."
      alert(this.status);

      console.log(error);
    });
  }

  preparationData(){
    debugger
    // если выбрана категория Specification
    if (this.selectedCategory == this.categories[0]){
      // обнулим Guid
      this.getGuid("");
    }
    // если выбрана категория EcoSCADA
    else if (this.selectedCategory == this.categories[1]){
      // обнулим параметры кроме Guid
      for (var i = 0; i < this.newEditComponent.paramValueRowModels.length; i++){
        if (this.newEditComponent.paramValueRowModels[i].componentParameterName != "Guid")
          this.newEditComponent.paramValueRowModels[i].value = "";
      }
    }
    // если выбрана категория File
    else {
      for (var i = 0; i < this.newEditComponent.paramValueRowModels.length; i++){
        this.newEditComponent.paramValueRowModels[i].value = "";
      }
    }
  }

  initBlock(){
    debugger
    var typeDemand = this.types.find((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId).name == "Demand" ||
     this.types.find((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId).name == "";
    var tDemand = this.types.find((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId)?.name.indexOf("Demand") != -1;
    var tPV = this.types.find((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId)?.name.indexOf("PV") != -1;
    var tDAM = this.types.find((q: { componentTypeId: number; })=>q.componentTypeId == this.newEditComponent.componentTypeId)?.name.indexOf("DAM") != -1;
    this.threeMode = tDemand || tPV || tDAM;
    this.fileName = "";
    this.loadingImage = false;
    this.loadError = false;
    this.loadSuccess = false;
    this.selectedCategory = this.categories[0];
  }

  paramsHaveGuid(){
    return this.newEditComponent.paramValueRowModels.map(q=>q.componentParameterName).indexOf("Guid") != -1;
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
        this.addedComponent.emit({"component":result,"newEditRow":this.newEditComponent});
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

  clickRadio(){
    debugger
    if (this.selectedCategory == this.categories[1]){
      if (!this.paramsHaveGuid()){
        alert("This type does not have a parameter named 'Guid'. Please add the specified parameter to enable this feature.");
        this.selectedCategory = this.categories[0];
      }
    }
  }

}
