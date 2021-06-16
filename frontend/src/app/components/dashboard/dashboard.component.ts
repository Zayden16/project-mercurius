import {Component, OnInit} from '@angular/core';
import {UserService} from 'src/app/services/user.service';
import {CustomerService} from "../../services/customer.service";
import {DocumentService} from "../../services/document.service";
import {ArticleService} from "../../services/article.service";
import {TaxRateService} from "../../services/tax-rate.service";
import {PlzService} from "../../services/plz.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  usersCount: number = 0;
  customerCount: number = 0;
  documentsCount: number = 0;
  articlesCount: number = 0;
  taxRatesCount: number = 0;
  postalCodesCount: number = 0;

  data: any;

  constructor(private userService: UserService, private customerService: CustomerService, private documentService: DocumentService,
              private articleService: ArticleService, private taxRateService: TaxRateService, private plzService: PlzService) {
  }

  async ngOnInit(): Promise<any> {
    this.usersCount = (await this.userService.getUsers()).length;
    this.customerCount = (await this.customerService.getCustomers()).length;
    this.documentsCount = (await this.documentService.getDocuments()).length;
    this.articlesCount = (await this.articleService.getArticles()).length;
    this.taxRatesCount = (await this.taxRateService.getTaxRates()).length;
    this.postalCodesCount = (await this.plzService.getPostalCodes()).length;

    this.data = {
      labels: ['Users', 'Customers', 'Documents', 'Articles', 'TaxRates', 'PostalCodes'],
      datasets: [
        {
          data: [this.usersCount, this.customerCount, this.documentsCount, this.articlesCount, this.taxRatesCount, this.postalCodesCount],
          backgroundColor: ['#ff0000', '#4287f5', '#FFFF00', '#FFC0CB', '#7f00ff', '#42f581']
        }]
    };
  }
}
