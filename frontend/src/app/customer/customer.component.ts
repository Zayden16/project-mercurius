import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/model/Customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customers: Customer[] = [
    {id: 1, firstName: "Yazdan", lastName: "Musa", address1: "Biberstras 5", address2: "6481 Rotheburg", email: "zayden@zayden.ch", plz: 5192},
    {id: 2, firstName: "Raphael", lastName: "Härtel", address1: "Schleuchtweg 184", address2: "5133 Cham", email: "ryu@ryuworld.ch", plz: 5192},
    {id: 1, firstName: "Yazdan", lastName: "Musa", address1: "Biberstras 5", address2: "6481 Rotheburg", email: "zayden@zayden.ch", plz: 5192},
    {id: 2, firstName: "Raphael", lastName: "Härtel", address1: "Schleuchtweg 184", address2: "5133 Cham", email: "ryu@ryuworld.ch", plz: 5192},
    {id: 1, firstName: "Yazdan", lastName: "Musa", address1: "Biberstras 5", address2: "6481 Rotheburg", email: "zayden@zayden.ch", plz: 5192},
    {id: 2, firstName: "Raphael", lastName: "Härtel", address1: "Schleuchtweg 184", address2: "5133 Cham", email: "ryu@ryuworld.ch", plz: 5192},
    {id: 1, firstName: "Yazdan", lastName: "Musa", address1: "Biberstras 5", address2: "6481 Rotheburg", email: "zayden@zayden.ch", plz: 5192},
    {id: 2, firstName: "Raphael", lastName: "Härtel", address1: "Schleuchtweg 184", address2: "5133 Cham", email: "ryu@ryuworld.ch", plz: 5192},
  ]
  
  constructor() { }

  ngOnInit(): void {

  }

}
