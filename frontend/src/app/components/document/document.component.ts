import {Component, OnInit} from '@angular/core';
import {ConfirmationService, SelectItem} from 'primeng/api';
import {DialogService, DynamicDialogModule} from 'primeng/dynamicdialog';
import {DocumentService} from 'src/app/services/document.service';
import {UserService} from 'src/app/services/user.service';
import {Document} from 'src/model/Document';
import {User} from 'src/model/User';
import {ArticlePositionComponent} from '../article-position/article-position.component';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CustomerService} from "../../services/customer.service";
import {Customer} from "../../../model/Customer";

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.scss'],
  providers: [DynamicDialogModule]
})
export class DocumentComponent implements OnInit {
  documents: Document[] = [];
  clonedDocuments: any;
  newDocument = {} as Document;
  newDocumentForm: FormGroup;

  creators: SelectItem[] = [];
  sendees: SelectItem[] = []

  displayDialog: boolean = false;
  submitted = false;

  constructor(private documentService: DocumentService, private userService: UserService, private customerService: CustomerService,
              private dialogService: DialogService, private confirmService: ConfirmationService, private formBuilder: FormBuilder) {
    this.newDocumentForm = this.formBuilder.group({
      number: [null, Validators.required],
      creatorId: [null, Validators.required],
      sendeeId: [null, Validators.required]
    });
  }

  async ngOnInit(): Promise<void> {
    this.documentService.getDocuments().then(data => this.documents = data);

    this.userService.getUsers().then(data => {
      data.forEach((user: User) => {
        this.creators.push({label: user.FirstName + user.LastName, value: user.Id});
      });
    });

    this.customerService.getCustomers().then(data => {
      data.forEach((customer: Customer) => {
        this.sendees.push({label: customer.FirstName + customer.LastName, value: customer.Id});
      });
    });
  }

  // Row Editor
  onRowEditInit(document: Document) {
    this.clonedDocuments[document.Id] = {...document};
  }

  onRowEditCancel(document: Document, index: number) {
    this.documents[index] = this.clonedDocuments[document.Id];
    delete this.clonedDocuments[document.Id];
  }

  // CRUD
  async createDocument() {
    this.submitted = true;

    if (this.newDocumentForm.invalid) {
      return;
    }

    await this.documentService.createDocument(this.newDocument);
    this.hideDialog()
  }

  async updateDocument(document: Document) {
    await this.documentService.updateDocument(document);
  }

  async deleteDocument(event: Event, document: Document) {
    this.confirmService.confirm({
      target: event.target!,
      message: 'Are you sure?',
      icon: 'pi pi-exclamation-triangle',
      accept: async () => {
        await this.documentService.deleteDocument(document.Id);
        delete this.documents[document.Id];
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

  showArticlePositionDialog(documentId: number) {
    this.dialogService.open(ArticlePositionComponent, {
      data: {
        documentId: documentId
      },
      header: 'Article Positions',
      width: '70%'
    });
  }

  // Form
  get newDocumentFormControls() {
    return this.newDocumentForm.controls;
  }
}
