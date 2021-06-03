import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from 'src/model/Customer'

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  getCustomers(){
    return this.httpClient.get('/placeholder/path')
                .toPromise()
                .then(res => <Customer[]> res.data)
                .then(data => { return data; })
  }
}
