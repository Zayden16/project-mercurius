import {Component, OnInit} from '@angular/core';
import {ConfirmationService} from 'primeng/api';
import {Article} from 'src/model/Article';
import {ArticleService} from '../../services/article.service';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})
export class ArticleComponent implements OnInit {
  articles: Article[] = [];
  clonedArticles: any;
  newArticle = {} as Article;
  newArticleForm: FormGroup;

  displayDialog: boolean = false;
  submitted = false;

  constructor(private articleService: ArticleService, private confirmService: ConfirmationService, private formBuilder: FormBuilder) {
    this.newArticleForm = this.formBuilder.group({
      title: [null, Validators.required],
      description: [null, Validators.required],
      price: [null, Validators.required],
      taxRate: [null, Validators.required],
      unit: [null, Validators.required],
    });
  }

  async ngOnInit(): Promise<void> {
    this.articleService.getArticles().then(data => this.articles = data);
  }

  // Row Editor
  onRowEditInit(article: Article) {
    this.clonedArticles[article.Id] = {...article};
  }

  onRowEditCancel(article: Article, index: number) {
    this.articles[index] = this.clonedArticles[article.Id];
    delete this.clonedArticles[article.Id];
  }

  // CRUD
  async createArticle() {
    this.submitted = true;

    if (this.newArticleForm.invalid) {
      return;
    }

    await this.articleService.createArticle(this.newArticle);
    this.hideDialog()
  }

  async updateArticle(article: Article) {
    await this.articleService.updateArticle(article);
  }

  async deleteArticle(event: Event, article: Article) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        await this.articleService.deleteArticle(article.Id);
        delete this.articles[article.Id];
      },
      reject: () => {
      }
    })

  }

  // Input Dialog
  showDialog() {
    this.displayDialog = true;
  }

  hideDialog() {
    console.log("test");
    this.displayDialog = false;
  }

  // Form
  get newArticleFormControls() {
    return this.newArticleForm.controls;
  }
}
