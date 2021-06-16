import {Component, OnInit} from '@angular/core';
import {ConfirmationService} from 'primeng/api';
import {Customer} from 'src/model/Customer';
import {CustomerService} from '../../services/customer.service';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {Plz} from "../../../model/Plz";
import {PlzService} from "../../services/plz.service";
import {SelectItem} from 'primeng/api';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  customers: Customer[] = [];
  clonedCustomers: any;
  newCustomer = {} as Customer;
  newCustomerForm: FormGroup;
  postalCodes: SelectItem[] = [];

  displayDialog: boolean = false;
  submitted = false;

  constructor(private customerService: CustomerService, private confirmService: ConfirmationService, private formBuilder: FormBuilder,
              private plzService: PlzService) {
    this.newCustomerForm = this.formBuilder.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      address1: [null, Validators.required],
      address2: [null],
      email: [null, [Validators.required, Validators.email]],
      plzId: [null, Validators.required]
    });
  }

  async ngOnInit(): Promise<void> {
    this.customerService.getCustomers().then(data => this.customers = data);
    this.plzService.getPostalCodes().then(data => {
      data.forEach((plz: Plz) => {
        this.postalCodes.push({label: plz.City, value: plz.Id});
      });
    });
  }

  // Row Editor
  onRowEditInit(customer: Customer) {
    this.clonedCustomers[customer.Id] = {...customer};
  }

  onRowEditCancel(customer: Customer, index: number) {
    this.customers[index] = this.clonedCustomers[customer.Id];
    delete this.clonedCustomers[customer.Id];
  }

  // CRUD
  async createCustomer() {
    this.submitted = true;

    if (this.newCustomerForm.invalid) {
      return;
    }

    await this.customerService.createCustomer(this.newCustomer);
    this.hideDialog()
  }

  async updateUser(customer: Customer) {
    await this.customerService.updateCustomer(customer);
  }

  async deleteCustomer(event: Event, customer: Customer) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.customerService.deleteCustomer(customer.Id);
        delete this.customers[customer.Id];
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
  get newCustomerFormControls() {
    return this.newCustomerForm.controls;
  }
}
