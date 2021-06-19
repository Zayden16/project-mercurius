import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { AppSettings } from 'src/appsettings';
import { Plz } from 'src/model/Plz';

@Injectable({
  providedIn: 'root'
})
export class PlzService {
  constructor(private httpClient: HttpClient, private messageService: MessageService) {
  }

  getPostalCodes(): Promise<Plz[]> {
    try {
      return this.httpClient.get<Plz[]>(AppSettings.BASE_URL + 'Plz').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createPlz(plz: Plz): Promise<void> {
    const body = {
      Number: plz.Number,
      City: plz.City
    };

    await this.httpClient.post(AppSettings.BASE_URL + 'Plz', body)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully created Plz',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to create Plz',
            detail: `Please check Input`
          });
        }
      });
  }

  async deletePlz(plzId: number): Promise<void> {
    await this.httpClient.delete(AppSettings.BASE_URL + `Plz/${plzId}`)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully deleted Plz',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to delete Plz',
            detail: `Please check Input`
          });
        }
      });
  }
}
