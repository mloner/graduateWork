import {Component, Input, OnInit, ViewEncapsulation} from '@angular/core';
import {UserInfoModel} from "../../_shared/services/models/user-info.model";
import {AuthService} from "../../_shared/services/auth.service";

@Component({
  selector: 'app-site-header',
  templateUrl: './site-header.component.html',
  styleUrls: ['./site-header.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class SiteHeaderComponent implements OnInit {

  @Input() userData!: UserInfoModel;
  name: string = "Your Name";
  logoutModal: any;

  constructor(private authService: AuthService) {
  }

  ngOnInit(): void {
    var  x = this.authService.getUserInfo().subscribe(
      result => {
        this.name = result.username;
      })
  }

  // Modal Close
  closeModal(event:any) {
    event.preventDefault();
    event.stopPropagation();
    if(event.target.classList.contains("modal")) {
      this.logoutModal = false;

    }
  }

  public logout(): any {
    this.authService.logout().catch();
  }

}
