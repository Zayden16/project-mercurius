import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';
import { AppSettings } from 'src/appsettings';
import { Article } from 'src/model/Article';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  constructor(private httpClient: HttpClient, private messageService: MessageService) {
  }

  getArticles(): Promise<Article[]> {
    try {
      return this.httpClient.get<Article[]>(AppSettings.BASE_URL + 'Article').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createArticle(article: Article): Promise<void> {
    const body = {
      Title: article.Title,
      Description: article.Description,
      Price: article.Price,
      TaxRate: article.TaxRate,
      Unit: article.Unit
    };

    await this.httpClient.post(AppSettings.BASE_URL + 'Article', body)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully created Article',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to create Article',
            detail: `Please check Input`
          });
        }
      });
  }

  async updateArticle(article: Article): Promise<void> {
    const body = {
      Id: article.Id,
      Title: article.Title,
      Description: article.Description,
      Price: article.Price,
      TaxRate: article.TaxRate,
      Unit: article.Unit
    };

    await this.httpClient.put<Article>(AppSettings.BASE_URL + 'Article', body)
      .subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully modified Article',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to modify Article',
            detail: `Please check Input`
          });
        }
      });
  }

  async deleteArticle(articleId: number): Promise<void> {
    await this.httpClient.delete(AppSettings.BASE_URL + `Article/${articleId}`)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully deleted Article',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to delete Article',
            detail: `Please check Input`
          });
        }
      });
  }
}
