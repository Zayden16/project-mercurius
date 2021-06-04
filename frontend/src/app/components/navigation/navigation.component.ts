import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  constructor() { }

  items: MenuItem[] = [];

  ngOnInit(): void {
    this.items = [
      {
          label: 'Dashboard',
          icon: 'pi pi-home',
          routerLink: '/dashboard'
      },
      {
        label: 'Customers',
        icon: 'pi pi-users',
        items: [
          {label: 'Customers', icon: 'pi pi-user', routerLink: '/customers'},
          {label: 'PLZ Codes', icon: 'pi pi-map-marker', routerLink: '/plz'},
      ]
      },
      {
        label: 'Documents',
        icon: 'pi pi-file',
        routerLink: '/documents'
      },
      {
        label: 'Articles',
        icon: 'pi pi-briefcase',
        items: [
          {label: 'Articles', icon: 'pi pi-briefcase'},
          {label: 'Tax Rates', icon: 'pi pi-percentage'},
          {label: 'Article Units', icon: 'pi pi-tags'}
      ]
      },
      {
        label: 'Settings',
        icon: 'pi pi-cog',
        items: [
          {label: 'Users', icon: 'pi pi-user', routerLink: '/users'},
          {label: 'Sign Out', icon: 'pi pi-sign-out', routerLink:'/login'},
      ]
      }
  ];
  }
}
