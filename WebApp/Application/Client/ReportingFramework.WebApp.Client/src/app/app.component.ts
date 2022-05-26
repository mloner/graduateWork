import {Component, Inject} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ApiUrl} from "./app.module";
import {MainData} from './interfaces/MeteData.interfaces';
import {AuthService} from './_shared/services/auth.service';
import {UserInfoModel} from './_shared/services/models/user-info.model';
import {LocalStorageService} from './_shared/services/local-storage.service';
import {Router, NavigationEnd} from '@angular/router';
import {PrimeNGConfig} from 'primeng/api';
import {DomSanitizer} from '@angular/platform-browser';

import {environment} from "../environments/environment";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(
    private http: HttpClient,
    @Inject(ApiUrl) private apiUrl: string,
    private router: Router,
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private primengConfig: PrimeNGConfig,
    public domSanitizer: DomSanitizer) {
    //const userInfo = this.localStorageService.getUserInfo();
  }
  title = 'Client';
  // data!: any;
  static brand: string | undefined;
  public userData!: UserInfoModel;
  public data?: MainData;
  public base64Image!: any;

  ngOnInit(): any {
    this.primengConfig.ripple = true;
  }
}
