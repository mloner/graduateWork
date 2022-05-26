import {InjectionToken, NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { AppComponent } from './app.component';
import {environment} from "../environments/environment";
import { EquipmentComponent } from './content-components/equipment/equipment.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { DialogDeleteEditComponent } from './element-components/dialog-delete-edit/dialog-delete-edit.component';
import {MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldModule} from "@angular/material/form-field";
import {MatDialogModule} from "@angular/material/dialog";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MatNativeDateModule} from "@angular/material/core";
import {MatSelectModule} from "@angular/material/select";
import {MatButtonModule} from "@angular/material/button";
import { MatSortModule } from '@angular/material/sort';
import {SiteFooterComponent} from "./layout/site-footer/site-footer.component";
import {SiteHeaderComponent} from "./layout/site-header/site-header.component";
import {SiteLayoutComponent} from "./layout/site-layout/site-layout.component";
import {SiteSidebarComponent} from "./layout/site-sidebar/site-sidebar.component";
import { EditButtonComponent } from './element-components/edit-button/edit-button.component';
import { DeleteButtonComponent } from './element-components/delete-button/delete-button.component';
import { AddButtonComponent } from './element-components/add-button/add-button.component';
import { TypeComponent } from './content-components/type/type.component';
import { EditTypeComponent } from './element-components/edit-type/edit-type.component';
import { AddTypeComponent } from './element-components/add-type/add-type.component';
import { ParametersComponent } from './content-components/parameters/parameters.component';
import { EditParameterComponent } from './element-components/edit-parameter/edit-parameter.component';
import { AddParameterComponent } from './element-components/add-parameter/add-parameter.component';
import { ButtonModule } from 'primeng/button';
import {RippleModule} from "primeng/ripple";
import {LogoutComponent} from "./logout/logout.component";
import {ProfileComponent} from "./content-components/profile/profile.component";
import {AuthService} from "./_shared/services/auth.service";
import {LocalStorageService} from "./_shared/services/local-storage.service";
import {AuthInterceptor} from "./_shared/interceptors/auth.interceptor";
import {HttpErrorInterceptor} from "./_shared/interceptors/http-error.interceptor";
import { FilesComponent } from './content-components/files/files.component';
import {MatIconModule} from "@angular/material/icon";
import {MatProgressBarModule} from "@angular/material/progress-bar";
import { OptionDeleteComponentComponent } from './element-components/option-delete-component/option-delete-component.component';
import { DeleteEquipmentComponent } from './element-components/delete-equipment/delete-equipment.component';
import { ConfigurationComponent } from './content-components/configuration/configuration.component';
import { NewConfigurationComponent } from './element-components/new-configuration/new-configuration.component';
import {ClipboardModule} from "ngx-clipboard";
import { DeleteConfigurationComponent } from './element-components/delete-configuration/delete-configuration.component';
import { EditConfigurationComponent } from './element-components/edit-configuration/edit-configuration.component';
import { WatchConfigurationComponent } from './element-components/watch-configuration/watch-configuration.component';
import { SaveConfigurationComponent } from './element-components/save-configuration/save-configuration.component';
import { SaveChangesConfigurationComponent } from './element-components/save-changes-configuration/save-changes-configuration.component';
import { DiagramComponent } from './content-components/diagram/diagram.component';
import {NgxJsonViewerModule} from "ngx-json-viewer";
import { DeleteTypeComponent } from './element-components/delete-type/delete-type.component';
import { DeleteParameterComponent } from './element-components/delete-parameter/delete-parameter.component';
import {TableModule} from "primeng/table";
import {SharedModule} from "primeng/api";
import { ConfigBuildingsComponent } from './element-components/config-buildings/config-buildings.component';
import {CheckboxModule} from "primeng/checkbox";
import {SelectButtonModule} from "primeng/selectbutton";
import {InputSwitchModule} from "primeng/inputswitch";
import {FileUploadModule} from "primeng/fileupload";
import {RadioButtonModule} from "primeng/radiobutton";
import {InputTextModule} from "primeng/inputtext";
import {TemplatesComponent} from "./content-components/templates/templates.component";

export const ApiUrl = new InjectionToken('ApiUrl');

@NgModule({
  declarations: [
    AppComponent,
    EquipmentComponent,
    TemplatesComponent,
    DialogDeleteEditComponent,

    SiteFooterComponent,
    SiteHeaderComponent,
    SiteLayoutComponent,
    SiteSidebarComponent,
    EditButtonComponent,
    DeleteButtonComponent,
    AddButtonComponent,
    TypeComponent,
    EditTypeComponent,
    AddTypeComponent,
    ParametersComponent,
    EditParameterComponent,
    AddParameterComponent,

    LogoutComponent,
    ProfileComponent,
    FilesComponent,
    OptionDeleteComponentComponent,
    DeleteEquipmentComponent,
    ConfigurationComponent,
    NewConfigurationComponent,
    DeleteConfigurationComponent,
    EditConfigurationComponent,
    WatchConfigurationComponent,
    SaveConfigurationComponent,
    SaveChangesConfigurationComponent,
    DiagramComponent,
    DeleteTypeComponent,
    DeleteParameterComponent,
    ConfigBuildingsComponent,
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RouterModule,
        MatFormFieldModule,
        MatDialogModule,
        BrowserAnimationsModule,
        MatNativeDateModule,
        MatButtonModule,
        MatSelectModule,
        ReactiveFormsModule,
        MatSortModule,
        AppRoutingModule,
        ButtonModule,
        RippleModule,
        MatIconModule,
        MatProgressBarModule,
        ClipboardModule,
        NgxJsonViewerModule,
        TableModule,
        SharedModule,
        CheckboxModule,
        SelectButtonModule,
        InputSwitchModule,
        FileUploadModule,
        RadioButtonModule,
        InputTextModule,
    ],
  providers: [
    AuthService,
    LocalStorageService,
    {provide: ApiUrl, useValue: environment.apiUrl},
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true},
    {provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: {appearance: 'fill'}},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
