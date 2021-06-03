import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/model/Customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customers: Customer[] = [  ]
  
  constructor() { }

  ngOnInit(): void {

  }

}
