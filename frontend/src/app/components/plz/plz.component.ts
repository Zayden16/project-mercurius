import {Component, OnInit} from '@angular/core';
import {ConfirmationService, MessageService} from 'primeng/api';
import {PlzService} from 'src/app/services/plz.service';
import {Plz} from 'src/model/Plz';
import {TaxRate} from "../../../model/TaxRate";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-plz',
  templateUrl: './plz.component.html',
  styleUrls: ['./plz.component.scss']
})
export class PlzComponent implements OnInit {

  plzs: Plz[] = [];
  newPlz = {} as Plz;
  newPlzForm: FormGroup;

  displayDialog: boolean = false;
  submitted = false;

  constructor(private plzService: PlzService, private messageService: MessageService, private confirmService: ConfirmationService, private formBuilder: FormBuilder) {
    this.newPlzForm = this.formBuilder.group({
      percentage: [null, Validators.required],
      description: [null, Validators.required],
    });
  }

  async ngOnInit(): Promise<void> {
    this.plzs = await this.plzService.getPlzs();
    console.log(this.plzs);
    this.messageService.add({severity: 'success', summary: 'Service Message', detail: 'Via MessageService'});
  }

// CRUD
  async createTaxRate() {
    this.submitted = true;

    if (this.newPlzForm.invalid) {
      return;
    }

    //await this.plzService.createTaxRate(this.newPlz);
  }

  async deleteTaxRate(event: Event, taxRate: TaxRate) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        //this.plzService.deleteTaxRate(taxRate.Id);
        delete this.plzs[taxRate.Id];
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

  // Validation
  get newPlzFormControls() {
    return this.newPlzForm.controls;
  }
}
