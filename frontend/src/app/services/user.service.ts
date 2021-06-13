import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Message, MessageService} from 'primeng/api';
import {AppSettings} from 'src/appsettings';
import {User} from 'src/model/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private httpClient: HttpClient, private messageService: MessageService) {
  }

  getUsers(): Promise<User[]> {
    try {
      return this.httpClient.get<User[]>(AppSettings.BASE_URL + 'User').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createUser(user: User): Promise<any> {
    return this.httpClient.post(AppSettings.BASE_URL + 'User',{
      User_FirstName: user.User_FirstName,
      User_LastName: user.User_LastName,
      User_DisplayName: user.User_DisplayName,
      User_Mail: user.User_Mail,
      User_Password: user.User_Password
    }).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Successfully created User',
          detail: `Success`
        });
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Failed to create User',
          detail: `Please check Input`
        });
      }
    });
  }

  async updateUser(user: User): Promise<any> {
    const body = {
      User_Id: user.User_Id,
      User_FirstName: user.User_FirstName,
      User_LastName: user.User_LastName,
      User_DisplayName: user.User_DisplayName,
      User_Mail: user.User_Mail,
      User_Password: user.User_Password
    };

    return this.httpClient.put<User>(AppSettings.BASE_URL + 'User', body)
    .subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Successfully modified User',
          detail: `Success`
        });
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Failed to modify User',
          detail: `Please check Input`
        });
      }
    });
  }

  async deleteUser(userId: number): Promise < any > {
    this.httpClient.delete(AppSettings.BASE_URL + `User/${userId}`)
    .subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Successfully Deleted User',
          detail: `Success`
        });
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Failed to Delete User',
          detail: `Please check Input`
        });
      }
    });
  }
}
