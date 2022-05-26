import {Component, EventEmitter, Inject, Input, OnInit, Output} from '@angular/core';
import {
  ComponentConfiguration,
  ConfigComponentProperty,
  ConfigurationModel, EditSaveConfiguration,
  Type
} from "../../interfaces/MeteData.interfaces";
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-save-changes-configuration',
  templateUrl: './save-changes-configuration.component.html',
  styleUrls: ['./save-changes-configuration.component.css']
})
export class SaveChangesConfigurationComponent implements OnInit {
  formModal: any;
  status: any;
  configuration: ConfigurationModel = {configurationId: -1, name: "", link: "", notDeleted: true, dateTime: ""};
  saveConfig: EditSaveConfiguration = {componentConfigurations: [], configurationPropertiesComponents: []};
  @Input() public configurationList!: ComponentConfiguration[];
  @Input() public configPropertyList!: ConfigComponentProperty[];
  @Input() public configurationId: any;

  constructor(@Inject(ApiUrl) private apiUrl: string, private http: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
    this.http.get<ConfigurationModel>(this.apiUrl + '/configuration/' + this.configurationId).subscribe(result=> {
      debugger
      this.configuration = result;
    }, error => {
      console.log(error);
    });
  }

  // Modal Close
  closeModal(event:any) {
    // event.preventDefault();
    event.stopPropagation();
    if(event.target.classList.contains("modal")) {
      this.formModal = false;
    }
  }

  buttonClick(){
    if (this.configurationList.length >1){
      this.http.get<ConfigurationModel>(this.apiUrl + '/configuration/' + this.configurationId).subscribe(result=> {
        debugger
        this.configuration = result;
        this.formModal = true;
      }, error => {
        console.log(error);
      });
    }
    else {
      alert("The configuration must have at least 2 components.");
    }
  }

  save(){
    debugger
    this.saveConfig.componentConfigurations = this.configurationList;
    this.saveConfig.configurationPropertiesComponents = this.configPropertyList.map(q=>q.configurationPropertiesComponents);
    this.http.put<any>(this.apiUrl + '/configuration/update/configurationId=' + this.configuration.configurationId + '&name=' + this.configuration.name,
      this.saveConfig).subscribe(result=> {
      debugger
      this.status = "Configuration changed successfully.";
      alert(this.status);
      this.router.navigate(['../configuration']);
    }, error => {
      this.status = "Error! Failed to change configuration."
      alert(this.status);
      console.log(error);
    });
  }
}
