import {NgModule} from '@angular/core';
import {Routes, RouterModule, DetachedRouteHandle, ActivatedRouteSnapshot} from '@angular/router';
import {RouteReuseStrategy} from '@angular/router';
import {AuthGuard} from './_shared/guards/auth.guard';
import {TemplatesComponent} from "./content-components/templates/templates.component";

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    component: TemplatesComponent,
    data: { shouldReuse: true }
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'templates',
    canActivate: [AuthGuard],
    component: TemplatesComponent,
    data: {shouldReuse: true},
  }
];


export class CustomRouteReuseStategy implements RouteReuseStrategy {

  handlers: { [key: string]: DetachedRouteHandle } = {};
  storedRouteHandles = new Map<string, DetachedRouteHandle>();

  shouldDetach(route: ActivatedRouteSnapshot): boolean {
    return route.data.shouldReuse || false;
  }

  store(route: ActivatedRouteSnapshot, detachedTree: DetachedRouteHandle): void {
    if (route.data.shouldReuse) {
      this.storedRouteHandles.set(this.getPath(route), detachedTree);
    }
  }

  shouldAttach(route: ActivatedRouteSnapshot): boolean {
    return this.storedRouteHandles.has(this.getPath(route));
  }

  retrieve(route: ActivatedRouteSnapshot): any {
    if (!route.routeConfig) {
      return null;
    }
    return this.storedRouteHandles.get(this.getPath(route)) as DetachedRouteHandle;
  }

  shouldReuseRoute(future: ActivatedRouteSnapshot, curr: ActivatedRouteSnapshot): boolean {
    return future.data.shouldReuse || false;
  }

  private getPath(route: ActivatedRouteSnapshot): string {
    if (route.routeConfig !== null && route.routeConfig.path) {
      return route.routeConfig.path;
    }
    return '';
  }

}

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [{provide: RouteReuseStrategy, useClass: CustomRouteReuseStategy},],
})
export class AppRoutingModule {}
