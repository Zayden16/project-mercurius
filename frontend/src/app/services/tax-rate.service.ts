import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {MessageService} from 'primeng/api';
import {AppSettings} from 'src/appsettings';
import {TaxRate} from 'src/model/TaxRate';

@Injectable({
  providedIn: 'root'
})
export class TaxRateService {
  constructor(private httpClient: HttpClient, private messageService: MessageService) {
  }

  getTaxRates(): Promise<TaxRate[]> {
    try {
      return this.httpClient.get<TaxRate[]>(AppSettings.BASE_URL + 'TaxRate').toPromise();
    } catch (error) {
      return Promise.reject();
    }
  }

  async createTaxRate(taxRate: TaxRate): Promise<any> {
    return this.httpClient.post(AppSettings.BASE_URL + 'TaxRate', {
      TaxRate_Id: taxRate.Taxrate_Id,
      TaxRate_Percentage: taxRate.Taxrate_Percentage,
      TaxRate_Description: taxRate.Taxrate_Description
    }).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Successfully created TaxRate',
          detail: `Success`
        });
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Failed to create TaxRate',
          detail: `Please check Input`
        });
      }
    });
  }

  async updateTaxRate(taxRate: TaxRate): Promise<void> {
    const body = {
      TaxRate_Id: taxRate.Taxrate_Id,
      TaxRate_Percentage: taxRate.Taxrate_Percentage,
      TaxRate_Description: taxRate.Taxrate_Description
    };

    this.httpClient.put<TaxRate>(AppSettings.BASE_URL + 'TaxRate', body)
      .subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully modified TaxRate',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to modify TaxRate',
            detail: `Please check Input`
          });
        }
      });
  }

  async deleteTaxRate(taxRateId: number): Promise<void> {
    this.httpClient.delete(AppSettings.BASE_URL + `TaxRate/${taxRateId}`)
      .subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Successfully Deleted TaxRate',
            detail: `Success`
          });
        },
        error: () => {
          this.messageService.add({
            severity: 'error',
            summary: 'Failed to Delete TaxRate',
            detail: `Please check Input`
          });
        }
      });
  }
}