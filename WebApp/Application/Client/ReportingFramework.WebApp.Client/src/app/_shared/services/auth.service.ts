import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { UserManager, UserManagerSettings, User, WebStorageStateStore } from 'oidc-client';
import { environment } from 'src/environments/environment';
import { UserInfoModel } from './models/user-info.model';
import { Observable } from 'rxjs';
import { LocalStorageService } from './local-storage.service';

@Injectable()
export class AuthService extends BaseService {
  private manager = new UserManager(this.getClientSettings());
  private user!: User;
  private userInfo = new UserInfoModel();

  constructor(private httpClient: HttpClient, private localStorageService: LocalStorageService) {
    super();

    const storedUser = this.localStorageService.getLoggedUser();

    if (storedUser) {
      this.user = storedUser;
    }

    this.manager.getUser().then(user => {
      this.user = (user as User);
      this.localStorageService.setLoggedUser(this.user);
    });

    this.manager.events.addUserLoaded(args => {
      this.manager.getUser().then(user => {
        this.user = (user as User);
        this.localStorageService.setLoggedUser(this.user);
      });
    });
  }

  login(): any {
    return this.manager.signinRedirect();
  }

  logout(): any {
    this.localStorageService.removeLoggedUser();
    return this.manager.signoutRedirect();
  }

  getUserInfo(): Observable<UserInfoModel> {
    return this.httpClient.get<UserInfoModel>(`${this.baseUrl}/auth/user-info`);
  }

  getAuthorizationHeaderValue(): string | null {
    if (!this.user) {
      return null;
    }
    return `${this.user.token_type} ${this.user.access_token}`;
  }

  async completeAuthentication(): Promise<any> {
    let defUser: User;
    await this.manager.signinRedirectCallback().then((user) => {
       window.history.replaceState({}, window.document.title, window.location.origin + window.location.pathname);
       window.location.href = '/';
       defUser = user;
       this.user = defUser;
    });

    this.localStorageService.setLoggedUser(this.user);
    await this.manager.clearStaleState();
  }

  async completeSilentRenewal(): Promise<any> {
    this.user = (await this.manager.signinSilentCallback() as User);
    await this.manager.clearStaleState();
  }

  isAuthenticated(): boolean {
    return this.user as unknown as boolean && !this.user.expired;
  }

  hasAccess(permissionNames: string[]): boolean {
    if (!this.userInfo || !this.userInfo.username) {
      this.loadUser();
    }
    for (const permission of permissionNames) {
      if (this.userInfo.permissions.includes(permission)) {
        return true;
      }
    }
    return false;
  }

  getUsername(): string {
    if (!this.userInfo || !this.userInfo.username) {
      this.loadUser();
    }
    return this.userInfo.username;
  }

  private getClientSettings(): UserManagerSettings {
    const config = {
      authority: environment.ssoUrl,
      client_id: 'reporting.web',
      redirect_uri: environment.localUrl + '/auth/auth-callback',
      response_type: 'id_token token',
      scope: 'openid profile reporting.api.access custom.userinfo',
      userStore: new WebStorageStateStore({ store: window.localStorage }),
      staleStateAge: 300,
      automaticSilentRenew: true,
      silent_redirect_uri: environment.localUrl + '/auth/silent-renew-callback',
    };

    return config;
  }

  private loadUser(): any {
    this.userInfo = this.localStorageService.getUserInfo();
    if (!this.userInfo) {
      this.userInfo = new UserInfoModel();
    }
  }
}
