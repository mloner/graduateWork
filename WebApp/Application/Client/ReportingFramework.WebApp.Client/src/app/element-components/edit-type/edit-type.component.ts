import {Component, Inject, Input, OnInit, Output, EventEmitter} from '@angular/core';
import {NewEditComponentRow, ParamValueRowModels, Type} from "../../interfaces/MeteData.interfaces";
import {environment} from "../../../environments/environment";
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-edit-type',
  templateUrl: './edit-type.component.html',
  styleUrls: ['./edit-type.component.css']
})
export class EditTypeComponent implements OnInit {
  formModal: any;
  status: any;
  @Input() public type!: Type;
  @Output() public editedType = new EventEmitter();

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
    this.http.put<Type>(this.apiUrl + '/components/types/update', this.type).subscribe(result=> {
      debugger
      this.type = result;
      this.status = "Component type changed."
      alert(this.status);
      this.formModal = false;
      this.editedType.emit(result);

      //console.log(this.type);

    }, error => {
      this.status = "Error! Failed to change component type."
      alert(this.status);

      console.log(error);
    });
  }

  clickFlagParent(){
    this.type.haveParent = !this.type.haveParent;
  }

}
