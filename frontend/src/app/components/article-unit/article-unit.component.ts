import { Component, OnInit } from '@angular/core';
import { ArticleUnit } from 'src/model/ArticleUnit';
import { ArticleUnitService } from '../../services/article-unit.service';

@Component({
  selector: 'app-article-unit',
  templateUrl: './article-unit.component.html',
  styleUrls: ['./article-unit.component.scss']
})
export class ArticleUnitComponent implements OnInit {
  articleUnits: ArticleUnit[] = [];
  displayDialog: boolean = false;
  submitted = false;

  constructor(private articleUnitService: ArticleUnitService) {
  }

  async ngOnInit(): Promise<void> {
    this.articleUnitService.getArticleUnits().then(data => this.articleUnits = data);
  }
}
