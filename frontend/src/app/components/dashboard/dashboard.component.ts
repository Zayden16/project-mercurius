import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/model/User';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  usersCount: number = 0;
  documents: Document[] = [];
  documentsCount: number = 0;
  articlesCount: number = 0;

  data: any;

  constructor(private userService: UserService) {
    this.data = {
      labels: ['Users','Documents','Customers'],
      datasets: [
          {
              data: [300, 50, 100],
              backgroundColor: [
                  "#FF6384",
                  "#36A2EB",
                  "#FFCE56"
              ],
              hoverBackgroundColor: [
                  "#FF6384",
                  "#36A2EB",
                  "#FFCE56"
              ]
          }]    
      };
  }

  async ngOnInit(): Promise<any> {
    this.usersCount = (await this.userService.getUsers()).length;
  }
}
