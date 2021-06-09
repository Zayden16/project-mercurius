import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


import {ButtonModule} from 'primeng/button';
import { MenubarModule } from 'primeng/menubar';
import {CardModule} from 'primeng/card';
import {InputTextModule} from 'primeng/inputtext';
import {PanelMenuModule} from 'primeng/panelmenu';
import { NavigationComponent } from './components/navigation/navigation.component';
import {AvatarModule} from 'primeng/avatar';
import {KnobModule} from 'primeng/knob';
import {TableModule} from 'primeng/table';
import {MessageService} from 'primeng/api';
import {DialogModule} from 'primeng/dialog';
import {ToastModule} from 'primeng/toast';
import {ChartModule} from 'primeng/chart';
import {RippleModule} from 'primeng/ripple';



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

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
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
  ],
  providers: [HttpClientModule, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
