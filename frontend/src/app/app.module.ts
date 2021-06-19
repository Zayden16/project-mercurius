import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { ButtonModule } from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import { CardModule } from 'primeng/card';
import { InputTextModule } from 'primeng/inputtext';
import { PanelMenuModule } from 'primeng/panelmenu';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AvatarModule } from 'primeng/avatar';
import { KnobModule } from 'primeng/knob';
import { TableModule } from 'primeng/table';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogModule } from 'primeng/dialog';
import { ToastModule } from 'primeng/toast';
import { ChartModule } from 'primeng/chart';
import { RippleModule } from 'primeng/ripple';
import { DropdownModule } from 'primeng/dropdown';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { DialogService, DynamicDialogModule } from 'primeng/dynamicdialog';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './components/customer/customer.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DocumentComponent } from './components/document/document.component';
import { LoginComponent } from './components/login/login.component';
import { PlzComponent } from './components/plz/plz.component';
import { UserComponent } from './components/user/user.component';
import { ArticleComponent } from './components/article/article.component';
import { TaxRateComponent } from './components/tax-rate/tax-rate.component';
import { ArticleUnitComponent } from './components/article-unit/article-unit.component';
import { ArticlePositionComponent } from './components/article-position/article-position.component';


import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { EasterEggComponent } from './easter-egg/easter-egg.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    DashboardComponent,
    NavigationComponent,
    CustomerComponent,
    PlzComponent,
    DocumentComponent,
    UserComponent,
    ArticleComponent,
    TaxRateComponent,
    ArticleUnitComponent,
    ArticlePositionComponent,
    EasterEggComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MenubarModule,
    CardModule,
    ButtonModule,
    InputTextModule,
    PanelMenuModule,
    AvatarModule,
    KnobModule,
    TableModule,
    HttpClientModule,
    DialogModule,
    ToastModule,
    ChartModule,
    RippleModule,
    ReactiveFormsModule,
    FormsModule,
    DropdownModule,
    ConfirmPopupModule,
    DynamicDialogModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    HttpClientModule,
    MessageService,
    ConfirmationService,
    DialogService],
  bootstrap: [AppComponent]
})
export class AppModule { }
