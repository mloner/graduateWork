import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from '../_shared/guards/auth.guard';
import { AuthCallbackComponent } from './components/auth-callback/auth-callback.component';
import { SignoutCallbackComponent } from './components/signout-callback/signout-callback.component';
import { SilentRenewCallbackComponent } from './components/silent-renew-callback/silent-renew-callback.component';

const authRoutes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'auth-callback',
    component: AuthCallbackComponent,
  },
  {
    path: 'silent-renew-callback',
    component: SilentRenewCallbackComponent,
  },
  {
    path: 'signout-callback',
    component: SignoutCallbackComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(authRoutes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
