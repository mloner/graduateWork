import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UserModel } from "./models/user.model";
import { BaseService } from "./base.service";
import { UserDetailsModel } from "./models/user-details.model";

@Injectable()
export class UsersService extends BaseService {
    
    constructor(private httpClient: HttpClient) {
        super();
    }

    getUsers(instanceId: number): Observable<UserModel[]> {
        return this.httpClient.get<UserModel[]>(`${this.baseUrl}/users/instance/${instanceId}`);
    }

    getUserDetails(userGuid: string): Observable<UserDetailsModel> {
        return this.httpClient.get<UserDetailsModel>(`${this.baseUrl}/users/${userGuid}`);
    }
}