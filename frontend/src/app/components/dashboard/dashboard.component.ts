import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/model/User';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  users: User[] = [];
  usersCount: number = 0;
  rechnungen: number = 0;
  artikel: number = 0;

  constructor(private userService: UserService) {
  }

  async ngOnInit(): Promise<any> {
    this.users = await this.userService.getUsers();
    this.usersCount = this.users.length;
    this.rechnungen  = 420;
    this.artikel = 1291;
  }

}
