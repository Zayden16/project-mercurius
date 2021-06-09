import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { AppSettings } from 'src/appsettings';
import { Document } from 'src/model/Document';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {

  constructor(private httpClient: HttpClient, private messageService: MessageService) { }
  
  public log(message: string) {
    this.messageService.add({severity:'success', summary:'UserService', detail: message});
  }

  getDocuments(): Promise<Document[]>{
    try{
      return this.httpClient.get<Document[]>(AppSettings.BASE_URL+'Document').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

}
