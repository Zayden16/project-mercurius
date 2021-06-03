import {Component, OnInit} from '@angular/core';
import {MenuItem} from 'primeng/api';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
    title = 'Frontend';
    constructor(private primengConfig: PrimeNGConfig) {  }
  
    ngOnInit(): void{
      this.primengConfig.ripple = true;
    }
  }