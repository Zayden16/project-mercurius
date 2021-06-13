import {
  Component,
  OnInit
} from '@angular/core';
import {
  Router,
  RouterLink
} from '@angular/router';
import {
  MenuItem
} from 'primeng/api';
import {
  AuthenticationService
} from 'src/app/services/authentication.service';
import {
  User
} from 'src/model/User';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  constructor(private router: Router, private authService: AuthenticationService) {}

  items: MenuItem[] = [];
  user: User = this.authService.currentUserValue;
  userInitals: string = this.user.FirstName[0] + this.user.LastName[0]
  ngOnInit(): void {
    this.items = [{
        label: 'Dashboard',
        icon: 'pi pi-home',
        routerLink: '/dashboard'
      },
      {
        label: 'Customers',
        icon: 'pi pi-users',
        items: [{
            label: 'Customers',
            icon: 'pi pi-user',
            routerLink: '/customers'
          },
          {
            label: 'PLZ Codes',
            icon: 'pi pi-map-marker',
            routerLink: '/plz'
          },
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
          {label: 'Articles', icon: 'pi pi-briefcase', routerLink: '/article'},
          {label: 'Tax Rates', icon: 'pi pi-percentage', routerLink: '/tax-rate'},
          {label: 'Article Units', icon: 'pi pi-tags', routerLink: '/article-unit'}
      ]
      },
      {
        label: 'Settings',
        icon: 'pi pi-cog',
        items: [{
            label: 'Users',
            icon: 'pi pi-user',
            routerLink: '/users'
          },
          {
            label: 'Sign Out',
            icon: 'pi pi-sign-out',
            command: (event) => {
              this.logout();
            }
          },
        ]
      }
    ];
  }
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
