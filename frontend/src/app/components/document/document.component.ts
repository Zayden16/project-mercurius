import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/api';
import { DocumentService } from 'src/app/services/document.service';
import { UserService } from 'src/app/services/user.service';
import { Document } from 'src/model/Document';
import { User } from 'src/model/User';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.scss']
})
export class DocumentComponent implements OnInit {

  documents: Document[] = [];
  users: User[] = [];
  creators: SelectItem[] = [];
  clonedDocuments: any;
  newDocument =  {} as Document;
  displayDialog: boolean = false;

  constructor(private docService: DocumentService, private userService: UserService) { }

  async ngOnInit(): Promise<void> {
    this.documents = await this.docService.getDocuments();
    this.users = await this.userService.getUsers();
    this.users.forEach(user => {
      this.creators.push({label: user.FirstName + user.LastName, value: user.Id});
    });
  }

  showDialog(){
    this.displayDialog = true;
  }

}
