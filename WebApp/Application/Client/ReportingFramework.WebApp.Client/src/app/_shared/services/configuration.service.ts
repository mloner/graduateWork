import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseService } from "./base.service";
import { FisFunctionalityModel } from "./models/fis-functionality.model";
import { SystemModel } from "./models/system.model";

@Injectable()
export class ConfigurationService extends BaseService {
    
    constructor(private httpClient: HttpClient) {
        super();
    }

    getSystems(): Observable<SystemModel[]> {
        return this.httpClient.get<SystemModel[]>(`${this.baseUrl}/configuration/systems`)
    }

    getFisFunctionalities(): Observable<FisFunctionalityModel[]> {
        return this.httpClient.get<FisFunctionalityModel[]>(`${this.baseUrl}/configuration/fis/functionalities`);
    }
}