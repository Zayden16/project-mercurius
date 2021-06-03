import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Message, MessageService } from 'primeng/api';
import { AppSettings } from 'src/appsettings';
import { User } from 'src/model/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient, private messageService: MessageService) { }

  public log(message: string) {
    this.messageService.add({severity:'success', summary:'UserService', detail: message});
  }
  
  getUsers(): Promise<User[]>{
    try {
      return this.httpClient.get<User[]>(AppSettings.BASE_URL + 'User').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createUser(user: User): Promise<any>{
    return this.httpClient.post(AppSettings.BASE_URL + 'User',
      {
        "User_FirstName": user.User_FirstName,
        "User_LastName": user.User_LastName,
        "User_DisplayName": user.User_DisplayName,
        "User_Mail": user.User_Mail,
        "User_Password": user.User_Password
      });
  }
}
