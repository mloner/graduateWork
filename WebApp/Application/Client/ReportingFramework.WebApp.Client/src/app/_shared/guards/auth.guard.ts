import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, Route, CanActivateChild, CanLoad } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {
  constructor(private router: Router, private authService: AuthService) {}

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.checkAccess(next, state);
  }

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    return this.canActivate(childRoute, state);
  }

  canLoad(route: Route): boolean {
    return this.checkAccess(route, null as any);
  }
/*HERE*/
  private checkAccess(route: any, state: RouterStateSnapshot): any {
    const expectedPermissions: Array<string> = route.data.expectedPermissions;
    if (this.authService.isAuthenticated()) {
      if (!expectedPermissions || this.authService.hasAccess(expectedPermissions)) {
        return true;
      } else {
        this.router.navigate(['/error/401']);
        return false;
      }
    }

    if (state) {
      this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url }, replaceUrl: true });
    } else {
      this.router.navigate(['/auth/login']);
    }
    return false;
  }
}
