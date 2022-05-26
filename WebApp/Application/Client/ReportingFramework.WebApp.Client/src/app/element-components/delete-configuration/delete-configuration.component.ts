import {
  Component,
  Inject,
  OnInit,
  ElementRef,
  Input,
  ViewChild,
  ViewChildren,
  QueryList,
  Output,
  EventEmitter
} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ApiUrl} from "../../app.module";
import {environment} from "../../../environments/environment";
import {MatDialog} from "@angular/material/dialog";
import {DialogDeleteEditComponent} from "../dialog-delete-edit/dialog-delete-edit.component";
import {NewEditComponentRow, ParamValueRowModels, ComponentModel, Type, ComponentConfiguration,
  ConfigurationsComponentsModel, ConfigurationModel, ConfigurationElemModel} from "../../interfaces/MeteData.interfaces";
import { ClipboardService } from 'ngx-clipboard'

@Component({
  selector: 'app-delete-configuration',
  templateUrl: './delete-configuration.component.html',
  styleUrls: ['./delete-configuration.component.css']
})
export class DeleteConfigurationComponent implements OnInit {
  formModal: any;
  status: any;
  @Input() public configuration: any;
  @Output() public deletedConfigurator = new EventEmitter();

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
    this.http.delete<any>(this.apiUrl + '/configuration/remove/' + this.configuration.configurationModel.configurationId).subscribe(result=> {
      this.status = 'Delete successful.';
      alert(this.status);
      this.formModal = false;
      this.deletedConfigurator.emit(this.configuration);
    }, error => {
      this.status = "Error! Failed to remove configuration."
      alert(this.status);
      this.formModal = false;
      console.log(error);
    });
  }
}
