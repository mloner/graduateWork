import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthCallbackComponent } from './components/auth-callback/auth-callback.component';
import { LoginComponent } from './components/login/login.component';
import { SignoutCallbackComponent } from './components/signout-callback/signout-callback.component';
import { SilentRenewCallbackComponent } from './components/silent-renew-callback/silent-renew-callback.component';
import { AuthRoutingModule } from './auth.routing.module';



@NgModule({
  declarations: [AuthCallbackComponent, LoginComponent, SignoutCallbackComponent, SilentRenewCallbackComponent],
  imports: [
    CommonModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
