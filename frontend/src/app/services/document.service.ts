import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { AppSettings } from 'src/appsettings';
import { Document } from 'src/model/Document';
import { throwError } from "rxjs";

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
      TypeId: 1
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
      TypeId: 1
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

  async downloadDocument(documentId: number): Promise<void> {
    this.httpClient.get(AppSettings.BASE_URL + `Docgen/${documentId}`, {
      responseType: 'arraybuffer'
    }
    ).subscribe(response => this.downloadFile(response, "application/pdf"));
  }

  downloadFile(data: any, type: string) {
    let blob = new Blob([data], { type: type });
    let url = window.URL.createObjectURL(blob);
    let pwa = window.open(url);
    if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
      alert('Please disable your Pop-up blocker and try again.');
    }
  }
}
