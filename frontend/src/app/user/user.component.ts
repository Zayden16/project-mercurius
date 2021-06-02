import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { User } from 'src/model/User';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  users: User[] = [];
  clonedUsers: any;

  constructor(private userService: UserService, private messageService: MessageService) { }

  async ngOnInit(): Promise<void> {
    this.users = await this.userService.getUsers();
    console.log(this.users);
      this.messageService.add({severity:'success', summary:'Service Message', detail:'Via MessageService'});
  }

  onRowEditInit(user: User) {
    this.clonedUsers[user.User_Id] = {...user};
  }

  onRowEditSave(user: User) {
    if (user.User_Id > 0) {
        delete this.clonedUsers[user.User_Id];
        this.messageService.add({severity:'success', summary: 'Success', detail:'User is updated'});
    }  
    else {
        this.messageService.add({severity:'error', summary: 'Error', detail:'Invalid Price'});
    }
  }

  onRowEditCancel(user: User, index: number) {
    this.users[index] = this.clonedUsers[user.User_Id];
    delete this.clonedUsers[user.User_Id];
  }

}
