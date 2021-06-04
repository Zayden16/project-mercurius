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
    // this.users = await this.userService.getUsers();
    this.users = [
      {
        "User_Id": 1,
        "User_FirstName": "Comic",
        "User_LastName": "Sans MS",
        "User_DisplayName": "csms",
        "User_Mail": "csms@jk.ch",
        "User_Password": "string"
      },
      {
        "User_Id": 2,
        "User_FirstName": "Gritty",
        "User_LastName": "Benz",
        "User_DisplayName": "benziner",
        "User_Mail": "gas@bbzw.ch",
        "User_Password": "string"
      },
      {
        "User_Id": 3,
        "User_FirstName": "Vladimir",
        "User_LastName": "Putin",
        "User_DisplayName": "Влади́мир",
        "User_Mail": "gov@ru.ru",
        "User_Password": "string"
      },
      {
        "User_Id": 4,
        "User_FirstName": "Elon",
        "User_LastName": "Musk",
        "User_DisplayName": "dogelover42069",
        "User_Mail": "elon@tesla.com",
        "User_Password": "string"
      }
    ]
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
