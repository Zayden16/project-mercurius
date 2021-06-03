import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { User } from 'src/model/User';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  users: User[] = [];
  clonedUsers: any;
  displayDialog: boolean = false;
  newUser = {} as User;

  constructor(private userService: UserService, private messageService: MessageService) { }

  async ngOnInit(): Promise<void> {
    this.users = await this.userService.getUsers();
  }

  onRowEditInit(user: User) {
    this.clonedUsers[user.User_Id] = {...user};
  }

  onRowEditSave(user: User) {
    
  }

  onRowEditCancel(user: User, index: number) {
    this.users[index] = this.clonedUsers[user.User_Id];
    delete this.clonedUsers[user.User_Id];
  }

  onRowDelete(user: User) {
    delete this.users[user.User_Id];
  }

  async createUser(){
    console.log(await this.userService.createUser(this.newUser));
  }

  showDialog(){
    this.displayDialog = true;
  }
}
