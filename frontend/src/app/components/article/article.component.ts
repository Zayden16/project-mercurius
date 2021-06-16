import {Component, OnInit} from '@angular/core';
import {ConfirmationService, SelectItem} from 'primeng/api';
import {Article} from 'src/model/Article';
import {ArticleService} from '../../services/article.service';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {Plz} from "../../../model/Plz";
import {TaxRateService} from "../../services/tax-rate.service";
import {ArticleUnitService} from "../../services/article-unit.service";
import {TaxRate} from "../../../model/TaxRate";
import {ArticleUnit} from "../../../model/ArticleUnit";

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

  taxRates: SelectItem[] = [];
  articleUnits: SelectItem[] = [];

  displayDialog: boolean = false;
  submitted = false;

  constructor(private articleService: ArticleService, private confirmService: ConfirmationService, private formBuilder: FormBuilder,
              private taxRateService: TaxRateService, private articleUnitService: ArticleUnitService) {
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
    this.taxRateService.getTaxRates().then(data => {
      data.forEach((taxRate: TaxRate) => {
        this.taxRates.push({label: `${taxRate.Percentage}%`, value: taxRate.Id});
      });
    });
    this.articleUnitService.getArticleUnits().then(data => {
      data.forEach((articleUnit: ArticleUnit) => {
        this.articleUnits.push({label: articleUnit.Text, value: articleUnit.Id});
      });
    });
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
    this.displayDialog = false;
  }

  // Form
  get newArticleFormControls() {
    return this.newArticleForm.controls;
  }
}
