import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { Plz } from 'src/model/Plz';
import { PlzService } from '../../services/plz.service';
import { FormGroup, FormBuilder, Validators, AbstractControlOptions } from '@angular/forms';

@Component({
  selector: 'app-plz',
  templateUrl: './plz.component.html',
  styleUrls: ['./plz.component.scss']
})
export class PlzComponent implements OnInit {
  postalCodes: Plz[] = [];
  newPlz = {} as Plz;
  newPlzForm: FormGroup;

  displayDialog: boolean = false;
  submitted = false;

  constructor(private plzService: PlzService, private confirmService: ConfirmationService, private formBuilder: FormBuilder) {
    this.newPlzForm = this.formBuilder.group({
      number: [null, Validators.required],
      city: [null, Validators.required]
    });
  }

  async ngOnInit(): Promise<void> {
    this.plzService.getPostalCodes().then(data => this.postalCodes = data);
  }

  // CRUD
  async createPlz() {
    this.submitted = true;

    if (this.newPlzForm.invalid) {
      return;
    }

    await this.plzService.createPlz(this.newPlz);
    this.hideDialog()
  }

  async deletePlz(event: Event, plz: Plz) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        await this.plzService.deletePlz(plz.Id);
        delete this.postalCodes[plz.Id];
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
  get newPlzFormControls() {
    return this.newPlzForm.controls;
  }
}
