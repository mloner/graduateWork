import {Component, EventEmitter, Inject, Input, OnInit, Output} from '@angular/core';
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-delete-type',
  templateUrl: './delete-type.component.html',
  styleUrls: ['./delete-type.component.css']
})
export class DeleteTypeComponent implements OnInit {
  formModal: any;
  status: any;
  @Input() public componentType: any;
  @Output() public deletedComponentType = new EventEmitter();

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
    this.http.delete<any>(this.apiUrl + '/components/types/remove/' + this.componentType.componentTypeId).subscribe(result=> {
      this.status = 'Delete successful.';
      alert(this.status);
      this.formModal = false;
      this.deletedComponentType.emit(this.componentType);
    }, error => {
      this.status = "Error! Failed to remove component type."
      alert(this.status);
      this.formModal = false;
      console.log(error);
    });
  }

}
