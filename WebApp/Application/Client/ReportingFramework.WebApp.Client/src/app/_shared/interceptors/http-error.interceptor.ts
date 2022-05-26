import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { LocalStorageService } from '../services/local-storage.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService, private localStorageService: LocalStorageService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      retry(0),
      catchError((error: HttpErrorResponse) => {
        console.error(error);
        let message = '';

        if (error.error) {
          message = error.error;
        } else {
          switch (error.status) {
            case 406:
            case 409:
            case 500:
              message = error.error;
              break;
            case 404:
              message = 'Not found';
              break;
            case 401:
              message = 'Unauthorized';
              this.authService.logout().catch();
              break;
            case 0:
              message = 'Sever can\'t be reach';
              break;
            default:
              message = 'unknown error';
              break;
          }
        }
        return throwError(message);
      })
    );
  }
}
