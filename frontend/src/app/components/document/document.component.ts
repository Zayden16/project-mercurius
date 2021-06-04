import { Component, OnInit } from '@angular/core';
import { Document } from 'src/model/Document';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.scss']
})
export class DocumentComponent implements OnInit {

  documents: Document[] = [];
  clonedDocuments: any;
  newDocument =  {} as Document; 

  displayDialog: boolean = false;

  constructor() { }

  async ngOnInit(): Promise<void> {
  }

  showDialog(){
    this.displayDialog = true;
  }

}
