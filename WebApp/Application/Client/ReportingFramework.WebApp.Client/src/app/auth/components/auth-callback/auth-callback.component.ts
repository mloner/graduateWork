import {Component, Inject, OnInit} from '@angular/core';
import { AuthService } from 'src/app/_shared/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { LocalStorageService } from 'src/app/_shared/services/local-storage.service';
import {DataSharingService} from "../../../_shared/services/dataSharing.service";
import {ApiUrl} from "../../../app.module";

@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styleUrls: ['./auth-callback.component.scss'],
})
export class AuthCallbackComponent implements OnInit {
  loader = 'authLoader';


  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private localStorageService: LocalStorageService,

  ) {
  }

  async ngOnInit() {
    if (this.route.snapshot.fragment){
      if (this.route.snapshot.fragment?.indexOf('error') >= 0) {
        this.router.navigate(['/error']);
        return;
      }
    }

    await this.authService.completeAuthentication();

    this.authService.getUserInfo().subscribe(
      result => {
        this.localStorageService.setUserInfo(result);
        /*this.dataSharingService.isUserLoggedIn.next(true);*/
        this.router.navigate(['/home']);
      },
      error => {
        this.router.navigate(['/error']);
      }
    );

  }
}
