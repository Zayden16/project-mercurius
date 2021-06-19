import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {MessageService} from 'primeng/api';
import {AppSettings} from 'src/appsettings';
import {ArticlePosition} from 'src/model/ArticlePosition';

@Injectable({
  providedIn: 'root'
})
export class ArticlePositionService {
  constructor(private httpClient: HttpClient, private messageService: MessageService) {
  }

  async getArticlePositionsByDocumentId(documentId: number): Promise<ArticlePosition[]> {
    try {
      return this.httpClient.get<ArticlePosition[]>(AppSettings.BASE_URL + `ArticlePosition/GetByDocumentId/${documentId}`).toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createArticlePosition(articlePosition: ArticlePosition): Promise<void> {
    const body = {
      ArticleId: articlePosition.ArticleId,
      DocumentId: articlePosition.DocumentId,
      Quantity: articlePosition.Quantity
    };

    await this.httpClient.post(AppSettings.BASE_URL + 'ArticlePosition', body)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully created ArticlePosition',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to create ArticlePosition',
            detail: `Please check Input`
          });
        }
      });
  }

  async updateArticlePosition(articlePosition: ArticlePosition): Promise<void> {
    const body = {
      Id: articlePosition.Id,
      ArticleId: articlePosition.ArticleId,
      DocumentId: articlePosition.DocumentId,
      Quantity: articlePosition.Quantity
    };

    await this.httpClient.put<ArticlePosition>(AppSettings.BASE_URL + 'ArticlePosition', body)
      .subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully modified ArticlePosition',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to modify ArticlePosition',
            detail: `Please check Input`
          });
        }
      });
  }

  async deleteArticlePosition(articlePositionId: number): Promise<void> {
    await this.httpClient.delete(AppSettings.BASE_URL + `ArticlePosition/${articlePositionId}`)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully deleted ArticlePosition',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to delete ArticlePosition',
            detail: `Please check Input`
          });
        }
      });
  }
}
