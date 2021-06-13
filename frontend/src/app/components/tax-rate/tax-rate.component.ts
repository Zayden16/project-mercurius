import {Component, OnInit} from '@angular/core';
import {ConfirmationService} from 'primeng/api';
import {TaxRate} from 'src/model/TaxRate';
import {TaxRateService} from '../../services/tax-rate.service';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-tax-rate',
  templateUrl: './tax-rate.component.html',
  styleUrls: ['./tax-rate.component.scss']
})
export class TaxRateComponent implements OnInit {
  taxRates: TaxRate[] = [];
  clonedTaxRates: any;
  displayDialog: boolean = false;
  newTaxRate = {} as TaxRate;

  newTaxRateForm: FormGroup;
  submitted = false;

  constructor(private taxRateService: TaxRateService, private confirmService: ConfirmationService, private formBuilder: FormBuilder) {
    this.newTaxRateForm = this.formBuilder.group({
      percentage: [null, Validators.required],
      description: [null, Validators.required],
    });
  }

  async ngOnInit(): Promise<void> {

    //this.taxRateService.getTaxRates().then(data => this.taxRates = data);

    this.taxRates = await this.taxRateService.getTaxRates();
    console.log(this.taxRates);
  }

  // Row Editor
  onRowEditInit(taxRate: TaxRate) {
    this.clonedTaxRates[taxRate.Id] = {...taxRate};
  }

  onRowEditSave(taxRate: TaxRate) {
    this.taxRateService.updateTaxRate(taxRate);
  }

  onRowEditCancel(taxRate: TaxRate, index: number) {
    this.taxRates[index] = this.clonedTaxRates[taxRate.Id];
    delete this.clonedTaxRates[taxRate.Id];
  }

  // CRUD
  async createTaxRate() {
    this.submitted = true;

    if (this.newTaxRateForm.invalid) {
      return;
    }

    await this.taxRateService.createTaxRate(this.newTaxRate);
    this.hideDialog()
  }

  async deleteTaxRate(event: Event, taxRate: TaxRate) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.taxRateService.deleteTaxRate(taxRate.Id);
        delete this.taxRates[taxRate.Id];
        location.reload();
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

  // Validation
  get newTaxRateFormControls() {
    return this.newTaxRateForm.controls;
  }
}
