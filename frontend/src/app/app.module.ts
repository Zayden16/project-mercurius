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
import { NavigationComponent } from './navigation/navigation.component';
import {AvatarModule} from 'primeng/avatar';
import {KnobModule} from 'primeng/knob';
import {TableModule} from 'primeng/table';
import {MessageService} from 'primeng/api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CustomerComponent } from './customer/customer.component';
import { PlzComponent } from './plz/plz.component';
import { DocumentComponent } from './document/document.component';
import { UserComponent } from './user/user.component';

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

  ],
  providers: [HttpClientModule, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
