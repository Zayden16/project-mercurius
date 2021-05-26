import {Component, OnInit} from '@angular/core';
import {MenuItem} from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
    title = 'Zayden';
    menuItems!: MenuItem[];
    activeItem!: MenuItem;
    constructor(private primengConfig: PrimeNGConfig) {  }
  
    ngOnInit(): void{
      this.menuItems = [
        {label: 'Home', icon: 'pi pi-fw pi-home', routerLink: ['/home']},
      ];
      this.activeItem = this.menuItems[0];
      this.primengConfig.ripple = true;
    }
  }