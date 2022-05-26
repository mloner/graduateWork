import {Component, EventEmitter, Inject, Input, OnInit, Output} from '@angular/core';
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-delete-parameter',
  templateUrl: './delete-parameter.component.html',
  styleUrls: ['./delete-parameter.component.css']
})
export class DeleteParameterComponent implements OnInit {
  formModal: any;
  status: any;
  @Input() public parameter: any;
  @Output() public deletedParameter = new EventEmitter();

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
    this.http.delete<any>(this.apiUrl + '/components/parameters/remove/' + this.parameter.componentParameterId).subscribe(result=> {
      this.status = 'Delete successful.';
      alert(this.status);
      this.formModal = false;
      this.deletedParameter.emit(this.parameter);
    }, error => {
      this.status = "Error! Failed to remove component parameter."
      alert(this.status);
      this.formModal = false;
      console.log(error);
    });

  }
}
