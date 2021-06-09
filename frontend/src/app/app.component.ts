import {Component, OnInit} from '@angular/core';
import {MenuItem} from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';
import { User } from 'src/model/User';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
    title = 'Mercurius';
    currentUser: User | undefined;

    constructor(private primengConfig: PrimeNGConfig,   private authService: AuthenticationService) { 
      this.authService.currentUser.subscribe(x => this.currentUser  = x);
     }
  
    ngOnInit(): void{
      this.primengConfig.ripple = true;
    }
  }