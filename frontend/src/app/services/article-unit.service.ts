import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppSettings } from 'src/appsettings';
import { ArticleUnit } from 'src/model/ArticleUnit';

@Injectable({
  providedIn: 'root'
})
export class ArticleUnitService {
  constructor(private httpClient: HttpClient) {
  }

  getArticleUnits(): Promise<ArticleUnit[]> {
    try {
      return this.httpClient.get<ArticleUnit[]>(AppSettings.BASE_URL + 'ArticleUnit').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }
}
