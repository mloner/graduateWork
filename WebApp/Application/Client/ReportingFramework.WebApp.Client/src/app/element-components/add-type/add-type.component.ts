import {Component, Inject, Input, OnInit, Output, EventEmitter} from '@angular/core';
import {NewEditComponentRow, ParamValueRowModels, Type} from "../../interfaces/MeteData.interfaces";
import {environment} from "../../../environments/environment";
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-add-type',
  templateUrl: './add-type.component.html',
  styleUrls: ['./add-type.component.css']
})
export class AddTypeComponent implements OnInit {
  formModal: any;
  status: any;
  type = {name:"Name", haveParent:true};
  @Output() public addedType = new EventEmitter();

  constructor(@Inject(ApiUrl) private apiUrl: string, private http: HttpClient) { }

  ngOnInit(): void {
  }

  // Modal Close
  closeModal(event:any) {
    // event.preventDefault();
    event.stopPropagation();
    if(event.target.classList.contains("modal")) {
      this.formModal = false;
    }
  }

  save(){
    this.http.post<Type>(this.apiUrl + '/components/types/newComponentType', this.type).subscribe(result=> {
      this.type = result;
      this.status = "Component type created successfully."
      alert(this.status);
      this.formModal = false;
      this.addedType.emit(result);

      //console.log(this.type);

    }, error => {
      this.status = "Error! Failed to create component type."
      alert(this.status);

      console.log(error);
    });
  }

  clickFlagParent(){
    this.type.haveParent = !this.type.haveParent;
  }

}
