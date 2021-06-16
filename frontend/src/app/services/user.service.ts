import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {MessageService} from 'primeng/api';
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

  async createUser(user: User): Promise<void> {
    const body = {
      FirstName: user.FirstName,
      LastName: user.LastName,
      DisplayName: user.DisplayName,
      Mail: user.Mail,
      Password: user.Password
    };

    await this.httpClient.post(AppSettings.BASE_URL + 'User', body)
      .subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully created User',
            detail: `Success`
          });
          location.reload();
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

  async updateUser(user: User): Promise<void> {
    const body = {
      Id: user.Id,
      FirstName: user.FirstName,
      LastName: user.LastName,
      DisplayName: user.DisplayName,
      Mail: user.Mail,
      Password: user.Password
    };

    await this.httpClient.put<User>(AppSettings.BASE_URL + 'User', body)
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

  async deleteUser(userId: number): Promise<void> {
    await this.httpClient.delete(AppSettings.BASE_URL + `User/${userId}`)
      .subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully Deleted User',
            detail: `Success`
          });
          location.reload();
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
