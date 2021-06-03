import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { AppSettings } from 'src/appsettings';
import { Plz } from 'src/model/Plz';

@Injectable({
  providedIn: 'root'
})
export class PlzService {

  constructor(private httpClient: HttpClient, private messageService: MessageService) { }

  private log(message: string) {
    this.messageService.add({severity:'success', summary:'UserService', detail: message});
  }

  getPlzs(): Promise<Plz[]>{
    try {
      return this.httpClient.get<Plz[]>(AppSettings.BASE_URL + 'Plz').toPromise();
    } catch (error) {
      this.log(error);
      return Promise.reject();
    }
  }
  
}
