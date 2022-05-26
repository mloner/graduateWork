import {Component, OnInit} from '@angular/core';
import {UserInfoModel} from "../../_shared/services/models/user-info.model";
import {ReportTemplateEditorService} from "../../services/reporting-service.service";
import {AuthService} from "../../_shared/services/auth.service";

@Component({
  selector: 'app-templates',
  templateUrl: './templates.component.html',
  styleUrls: ['./templates.component.css']
})
export class TemplatesComponent implements OnInit{

  userData!: UserInfoModel;

  templateEditorLink! : string;

  constructor(private reportTemplateEditorService : ReportTemplateEditorService,
              private authService: AuthService
  ) {
  }

  async ngOnInit(): Promise<void> {

  }

  async openTemplateEditor() : Promise<void>{
    this.userData = await this.authService.getUserInfo().toPromise();
    await this.reportTemplateEditorService.getLink(this.userData.username).toPromise().then(
      (resp) => {
        this.templateEditorLink = resp;
        window.open(this.templateEditorLink, "_blank");
      },
      (err) => {
        if(err.status == 404){
          alert('No editor found for this username');
        }
      });
  }

  async logoutTemplateEditor() : Promise<void>{
    window.open("https://us1.pdfgeneratorapi.com/logout", "_blank");
  }
}


