import {Component, EventEmitter, Inject, Input, OnInit, Output} from '@angular/core';
import {ComponentConfiguration, ConfigurationModel, Type, ConfigComponentProperty, EditSaveConfiguration} from "../../interfaces/MeteData.interfaces";
import {ApiUrl} from "../../app.module";
import {HttpClient} from "@angular/common/http";
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-save-configuration',
  templateUrl: './save-configuration.component.html',
  styleUrls: ['./save-configuration.component.css']
})
export class SaveConfigurationComponent implements OnInit {
  formModal: any;
  status: any;
  name: any = "Name configuration";
  saveConfig: EditSaveConfiguration = {componentConfigurations: [], configurationPropertiesComponents: []};
  @Input() public configurationList!: ComponentConfiguration[];
  @Input() public configPropertyList!: ConfigComponentProperty[];

  constructor(@Inject(ApiUrl) private apiUrl: string, private http: HttpClient, private router: Router) { }

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

  buttonClick(){
    if (this.configurationList.length >1){
      this.formModal = true;
    }
    else {
      alert("The configuration must have at least 2 components.");
    }
  }

  save(){
    debugger
    this.saveConfig.componentConfigurations = this.configurationList;
    this.saveConfig.configurationPropertiesComponents = this.configPropertyList.map(q=>q.configurationPropertiesComponents);
    this.http.post<ConfigurationModel>(this.apiUrl + '/configuration/newConfiguration/name=' + this.name, this.saveConfig).subscribe(result=> {
      debugger
      this.status = "Configuration created successfully.";
      alert(this.status);
      this.router.navigate(['../configuration']);
      }, error => {
      this.status = "Error! Failed to create configuration."
      alert(this.status);
      console.log(error);
    });
  }
}
