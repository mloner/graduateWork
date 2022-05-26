import { Injectable } from '@angular/core';
import { UserInfoModel } from './models/user-info.model';

@Injectable()
export class LocalStorageService {
  private loggedUserKey = 'auth.currentUser';
  private userInfoKey = 'auth.userInfo';

  setLoggedUser(user: any): any {
    localStorage.setItem(this.loggedUserKey, JSON.stringify(user));
  }

  getLoggedUser(): any {
    const userString = localStorage.getItem(this.loggedUserKey);
    if (userString) {
      return JSON.parse(userString);
    }
    return null;
  }

  removeLoggedUser(): any {
    localStorage.removeItem(this.loggedUserKey);
  }

  setUserInfo(userInfo: UserInfoModel): any {

    localStorage.setItem(this.userInfoKey, JSON.stringify(userInfo));
  }

  getUserInfo(): UserInfoModel {
    return JSON.parse(localStorage.getItem(this.userInfoKey) as string);
  }
}
