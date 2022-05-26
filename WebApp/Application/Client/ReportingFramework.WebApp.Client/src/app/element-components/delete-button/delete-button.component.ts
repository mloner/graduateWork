import {Component, Inject, Input, OnInit, Output, EventEmitter} from '@angular/core';
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";
import {NewEditComponentRow} from "../../interfaces/MeteData.interfaces";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-delete-button',
  templateUrl: './delete-button.component.html',
  styleUrls: ['./delete-button.component.css']
})
export class DeleteButtonComponent implements OnInit {
  formModal: any;
  status: any;
  @Input() public component: any;
  @Output() public deletedComponent = new EventEmitter();

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

  delete(){
    this.http.delete<any>(this.apiUrl + '/components/remove/' + this.component.componentId).subscribe(result=> {
      this.status = 'Delete successful.';
      alert(this.status);
      this.formModal = false;
      this.deletedComponent.emit(this.component);
    }, error => {
      this.status = "Error! Failed to remove component."
      alert(this.status);
      this.formModal = false;
      console.log(error);
    });

  }

}
