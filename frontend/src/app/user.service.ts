import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Message, MessageService } from 'primeng/api';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/appsettings';
import { User } from 'src/model/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient, private messageService: MessageService) { }

  private log(message: string) {
    this.messageService.add({severity:'success', summary:'UserService', detail: message});
  }

  getUsers(): Promise<User[]>{
    try {
      return this.httpClient.get<User[]>(AppSettings.BASE_URL + 'Users').toPromise();
    } catch (error) {
      this.log(error);
      return Promise.reject();
    }
  }

  createUser(user: User): void{
    this.httpClient.post<User>(AppSettings.BASE_URL + 'Users',
    {
      "user_FirstName": user.User_FirstName,
      "user_LastName": user.User_LastName,
      "user_DisplayName": user.User_DisplayName,
      "user_Mail": user.User_Mail,
      "user_Password": user.User_Password
    })
  }
}
