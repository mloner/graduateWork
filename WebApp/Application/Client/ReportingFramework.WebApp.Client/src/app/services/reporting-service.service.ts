import { HttpClient } from '@angular/common/http';
import {Inject, Injectable} from '@angular/core';
import {ApiUrl} from "../app.module";
import {Observable} from "rxjs";


@Injectable(
  {
    providedIn: 'root'
  })
export class ReportTemplateEditorService {

  constructor(@Inject(ApiUrl) private apiUrl: string,
              private http: HttpClient,
              ) {
  }

  getLink(username: string) : Observable<any> {
    return this.http.get(this.apiUrl + '/editors?username=' + username, {responseType : "text"});
  }
}
