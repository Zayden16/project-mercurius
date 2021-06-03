import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  umsatz: number = 0;
  rechnungen: number = 0;
  artikel: number = 0;

  constructor() {
  }

  ngOnInit(): void {
    this.umsatz = 50;
    this.rechnungen  = 420;
    this.artikel = 1291;
  }

}
