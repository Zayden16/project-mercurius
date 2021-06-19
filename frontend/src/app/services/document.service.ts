import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {MessageService} from 'primeng/api';
import {AppSettings} from 'src/appsettings';
import {Document} from 'src/model/Document';

@Injectable({
  providedIn: 'root'
})
export class DocumentService {
  constructor(private httpClient: HttpClient, private messageService: MessageService) {
  }

  async getDocuments(): Promise<Document[]> {
    try {
      return this.httpClient.get<Document[]>(AppSettings.BASE_URL + 'Document').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createDocument(document: Document): Promise<void> {
    const body = {
      Number: document.Number,
      CreatorId: document.CreatorId,
      SendeeId: document.SendeeId,
      StatusId: 1,
      TypeId: document.TypeId
    };

    await this.httpClient.post(AppSettings.BASE_URL + 'Document', body)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully created Document',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to create Document',
            detail: `Please check Input`
          });
        }
      });
  }

  async updateDocument(document: Document): Promise<void> {
    const body = {
      Id: document.Id,
      Number: document.Number,
      CreatorId: document.CreatorId,
      SendeeId: document.SendeeId,
      StatusId: 1,
      TypeId: document.TypeId
    };

    await this.httpClient.put<Document>(AppSettings.BASE_URL + 'Document', body)
      .subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully modified Document',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to modify Document',
            detail: `Please check Input`
          });
        }
      });
  }

  async deleteDocument(documentId: number): Promise<void> {
    await this.httpClient.delete(AppSettings.BASE_URL + `Document/${documentId}`)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully deleted Document',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to delete Document',
            detail: `Please check Input`
          });
        }
      });
  }
}
