import {Component, Inject, Input, OnInit, Output, EventEmitter} from '@angular/core';
import {ComponentModel, NewEditComponentRow, ParamValueRowModels, Type} from "../../interfaces/MeteData.interfaces";
import {environment} from "../../../environments/environment";
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-add-parameter',
  templateUrl: './add-parameter.component.html',
  styleUrls: ['./add-parameter.component.css']
})
export class AddParameterComponent implements OnInit {
  formModal: any;
  status: any;

  public parameter: ParamValueRowModels = {componentParameterId: 0, componentParameterName: "Name",
    pythonParam: "", unit: "", desctiption: "", componentValueId: 0, valueTypeId: 0, validity: true};

  @Input() public type!: number;
  @Input() public types: Type[] = [];
  @Output() public newParameter = new EventEmitter();

  constructor(@Inject(ApiUrl) private apiUrl: string, private http: HttpClient) {
  }

  // Modal Close
  closeModal(event:any) {
    event.preventDefault();
    event.stopPropagation();
    if(event.target.classList.contains("modal")) {
      this.formModal = false;
    }
  }

  add(){
    this.http.post<ParamValueRowModels>(this.apiUrl + '/components/parameters/newComponentParameter', this.parameter).subscribe(result=> {
      this.status = "Parameter created successfully.";
      alert(this.status);
      this.formModal = false;
      this.newParameter.emit(result)

    }, error => {
      this.status = "Error! Failed to create parameter."
      alert(this.status);
      console.log(error);
    });
  }

  getType(typeId: number){
    this.parameter.valueTypeId = typeId;
  }

  ngOnInit(): void {
  }

}
