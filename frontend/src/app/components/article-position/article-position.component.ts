import {Component, OnInit} from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {ConfirmationService, SelectItem} from 'primeng/api';
import {ArticlePositionService} from 'src/app/services/article-position.service';
import {ArticlePosition} from 'src/model/ArticlePosition';
import {DynamicDialogConfig} from 'primeng/dynamicdialog';
import {User} from "../../../model/User";
import {ArticleService} from "../../services/article.service";
import {Article} from "../../../model/Article";

@Component({
  selector: 'app-article-position',
  templateUrl: './article-position.component.html',
  styleUrls: ['./article-position.component.scss']
})
export class ArticlePositionComponent implements OnInit {
  documentId: number = 0;
  articlePositions: ArticlePosition[] = [];
  clonedArticlePositions: any;
  newArticlePosition = {} as ArticlePosition;
  newArticlePositionForm: FormGroup;

  articles: SelectItem[] = [];

  displayDialog: boolean = false;
  submitted = false;

  constructor(private articlePositionService: ArticlePositionService, private articleService: ArticleService,
              private confirmService: ConfirmationService, private formBuilder: FormBuilder, public config: DynamicDialogConfig) {
    this.newArticlePositionForm = this.formBuilder.group({
      articleId: [null, Validators.required],
      articleQuantity: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this.documentId = this.config.data.documentId;
    this.articlePositionService.getArticlePositionsByDocumentId(this.documentId).then(data => this.articlePositions = data);

    this.articleService.getArticles().then(data => {
      data.forEach((article: Article) => {
        this.articles.push({label: article.Title, value: article.Id});
      });
    });
  }

  // Row Editor
  onRowEditInit(articlePosition: ArticlePosition) {
    this.clonedArticlePositions[articlePosition.Id] = {...articlePosition};
  }

  onRowEditCancel(articlePosition: ArticlePosition, index: number) {
    this.articlePositions[index] = this.clonedArticlePositions[articlePosition.Id];
    delete this.clonedArticlePositions[articlePosition.Id];
  }

  // CRUD
  async createArticlePosition() {
    this.submitted = true;

    if (this.newArticlePositionForm.invalid) {
      return;
    }

    this.newArticlePosition.DocumentId = this.documentId;
    await this.articlePositionService.createArticlePosition(this.newArticlePosition);
    this.hideDialog()
  }

  async updateArticlePosition(articlePosition: ArticlePosition) {
    await this.articlePositionService.updateArticlePosition(articlePosition);
  }

  async deleteArticlePosition(event: Event, articlePosition: ArticlePosition) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        await this.articlePositionService.deleteArticlePosition(articlePosition.Id);
        delete this.articlePositions[articlePosition.Id];
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
    this.displayDialog = false;
  }

  // Form
  get newArticlePositionFormControls() {
    return this.newArticlePositionForm.controls;
  }
}
