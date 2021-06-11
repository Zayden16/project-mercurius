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

  public log(message: string) {
    this.messageService.add({severity: 'success', summary: 'UserService', detail: message});
  }

  getUsers(): Promise<User[]> {
    try {
      return this.httpClient.get<User[]>(AppSettings.BASE_URL + 'User').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createUser(user: User): Promise<any> {
    return this.httpClient.post(AppSettings.BASE_URL + 'User',
      {
        User_FirstName: user.User_FirstName,
        User_LastName: user.User_LastName,
        User_DisplayName: user.User_DisplayName,
        User_Mail: user.User_Mail,
        User_Password: user.User_Password
      }).subscribe({
      error: error => {
        /*this.errorMessage = error.message;*/
        console.error('There was an error!');
      }
    });
  }

  async updateUser(user: User): Promise<any> {
    user.User_Id = 19;
    user.User_FirstName = "Tom";
    user.User_LastName = "Holland";
    user.User_DisplayName = 'Spiderman';
    user.User_Mail = 'tom@gmx.com';
    user.User_Password = 'secret';

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
        error: error => {
          //this.errorMessage = error.message;
          console.error('There was an error!', error);
        }
      });

    /*return this.httpClient.put<User>(AppSettings.BASE_URL + 'User',
  {
    User_FirstName: user.User_FirstName,
    User_LastName: user.User_LastName,
    User_DisplayName: user.User_DisplayName,
    User_Mail: user.User_Mail,
    User_Password: user.User_Password
  }).subscribe({
  error: error => {
    /!*this.errorMessage = error.message;*!/
    console.error('There was an error!');
  }
});*/
  }

  async updateTaxRate(user: User): Promise<any> {
    const body = {
      Taxrate_Id: 9,
      Taxrate_Percentage: 5,
      Taxrate_Description: 'TaxRate'
    };

    return this.httpClient.put<any>(AppSettings.BASE_URL + 'TaxRate', body)
      .subscribe({
        error: error => {
          //this.errorMessage = error.message;
          console.error('There was an error!', error);
        }
      });
  }

  async deleteTaxRate(taxRateId: number): Promise<void> {
    this.httpClient.delete(AppSettings.BASE_URL + `TaxRate/${taxRateId}`)
      .subscribe({
        error: error => {
          //errorMessage = error.message;
          console.error('There was an error!');
        }
      });
  }
}
