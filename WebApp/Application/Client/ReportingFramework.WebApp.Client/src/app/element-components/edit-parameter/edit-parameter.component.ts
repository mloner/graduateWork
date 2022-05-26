import {Component, Inject, Input, OnInit, Output, EventEmitter} from '@angular/core';
import {ComponentModel, NewEditComponentRow, ParamValueRowModels, Type} from "../../interfaces/MeteData.interfaces";
import {environment} from "../../../environments/environment";
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-edit-parameter',
  templateUrl: './edit-parameter.component.html',
  styleUrls: ['./edit-parameter.component.css']
})
export class EditParameterComponent implements OnInit {
  formModal: any;
  status: any;

  @Input() public types: Type[] = [];
  @Input() public parameter!: ParamValueRowModels;
  @Output() public editParameter = new EventEmitter();

  constructor(@Inject(ApiUrl) private apiUrl: string, private http: HttpClient) { }

  // Modal Close
  closeModal(event:any) {
    event.preventDefault();
    event.stopPropagation();
    if(event.target.classList.contains("modal")) {
      this.formModal = false;
    }
  }

  save(){
    this.http.put<ParamValueRowModels>(this.apiUrl + '/components/parameters/update', this.parameter).subscribe(result=> {
      this.status = "Parameter changed."
      alert(this.status);
      this.formModal = false;
      this.editParameter.emit(result);

      //console.log("updateParameter");
      //console.log(this.parameter);

    }, error => {
      this.status = "Error! Failed to change parameter."
      alert(this.status);

      console.log(error);
    });
  }

  ngOnInit(): void {
  }

}
