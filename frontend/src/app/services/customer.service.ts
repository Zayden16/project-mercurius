import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {MessageService} from 'primeng/api';
import {AppSettings} from 'src/appsettings';
import {Customer} from 'src/model/Customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  constructor(private httpClient: HttpClient, private messageService: MessageService) {
  }

  getCustomers(): Promise<Customer[]> {
    try {
      return this.httpClient.get<Customer[]>(AppSettings.BASE_URL + 'Customer').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createCustomer(customer: Customer): Promise<void> {
    const body = {
      FirstName: customer.FirstName,
      LastName: customer.LastName,
      Address1: customer.Address1,
      Address2: customer.Address2,
      Email: customer.Email,
      PlzId: customer.PlzId
    };

    this.httpClient.post(AppSettings.BASE_URL + 'Customer', body)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully created Customer',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to create Customer',
            detail: `Please check Input`
          });
        }
      });
  }

  async updateCustomer(customer: Customer): Promise<void> {
    const body = {
      Id: customer.Id,
      FirstName: customer.FirstName,
      LastName: customer.LastName,
      Address1: customer.Address1,
      Address2: customer.Address2,
      Email: customer.Email,
      PlzId: customer.PlzId
    };

    this.httpClient.put<Customer>(AppSettings.BASE_URL + 'Customer', body)
      .subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully modified Customer',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to modify Customer',
            detail: `Please check Input`
          });
        }
      });
  }

  async deleteCustomer(customerId: number): Promise<void> {
    this.httpClient.delete(AppSettings.BASE_URL + `Customer/${customerId}`)
      .subscribe({
        next: () => {
          location.reload();
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully deleted Customer',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to delete Customer',
            detail: `Please check Input`
          });
        }
      });
  }
}
