import {Component, Inject, OnInit, ElementRef, Input, ViewChild, AfterViewInit, Renderer2} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ApiUrl} from "../../app.module";
import {MatDialog} from "@angular/material/dialog";
import * as go from "gojs";
import * as moment from "moment";
import JSONFormatter from "json-formatter-js";

@Component({
  selector: 'app-watch-configuration',
  templateUrl: './watch-configuration.component.html',
  styleUrls: ['./watch-configuration.component.css']
})
export class WatchConfigurationComponent implements OnInit {
  formModal: any;
  jsonConf: any = {"topology": {}, "elements": []};
  formatter: any;

  $:any = go.GraphObject.make;
  model:any = this.$(go.TreeModel);

  @ViewChild('json') jsonVal!: ElementRef;
  @Input() public configurationInput: any;
  @Input() public index: any;

  constructor(private http: HttpClient, @Inject(ApiUrl) private apiUrl: string, public dialog: MatDialog) {
  }

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

  getJson(){
    this.http.get<object>(this.apiUrl + '/configuration/json/configurationId=' + this.configurationInput.configurationModel.configurationId).subscribe(result=> {
      debugger
      this.jsonConf = result;
      this.getJsonTwo();
    }, error => {
      console.log(error);
    });
  }

  beautifyJsonStringTwo() {
    try {
      return JSON.stringify(this.jsonConf, null, 4);
    } catch (e) {}
    return "";
  }

  getJsonTwo(){
    const config = {
      hoverPreviewEnabled: true,
      hoverPreviewArrayCount: 1,
      hoverPreviewFieldCount: 1,
      theme: "",
      animateOpen: true,
      animateClose: true,
      useToJSON: true
    };
    debugger
    this.formatter = new JSONFormatter(this.jsonConf, 3, config);
    this.jsonVal.nativeElement.innerHTML = "";
    this.jsonVal.nativeElement.appendChild(this.formatter.render());
  }

  downloadJsonFile(){
    debugger
    const date = moment().format('YY-MM-DD HH-mm-ss');
    const blob = new Blob([this.beautifyJsonStringTwo()],{type: 'text/json'});
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    document.body.appendChild(link);
    link.setAttribute('style', 'display: none');
    link.href = url;
    link.download = this.configurationInput.configurationModel.name + " " + date + ".json";
    link.click();
    window.URL.revokeObjectURL(url);
    link.remove();
  }
}
