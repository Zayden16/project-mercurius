import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { PlzService } from 'src/app/services/plz.service';
import { Plz } from 'src/model/Plz';

@Component({
  selector: 'app-plz',
  templateUrl: './plz.component.html',
  styleUrls: ['./plz.component.scss']
})
export class PlzComponent implements OnInit {

  plzs: Plz[] = [];
  clonedPlzs: any;
  displayDialog: boolean = false;

  constructor(private plzService: PlzService, private messageService: MessageService) { }

  async ngOnInit(): Promise<void> {
    this.plzs = await this.plzService.getPlzs();
    console.log(this.plzs);
      this.messageService.add({severity:'success', summary:'Service Message', detail:'Via MessageService'});
  }

  onRowEditInit(plz: Plz) {
    this.clonedPlzs[plz.plz_Id] = {...plz};
  }

  onRowEditSave(plz: Plz) {
    if (plz.plz_Id > 0) {
        delete this.clonedPlzs[plz.plz_Id];
        this.messageService.add({severity:'success', summary: 'Success', detail:'User is updated'});
    }  
    else {
        this.messageService.add({severity:'error', summary: 'Error', detail:'Invalid Price'});
    }
  }

  onRowEditCancel(plz: Plz, index: number) {
    this.plzs[index] = this.clonedPlzs[plz.plz_Id];
    delete this.plzs[plz.plz_Id];
  }

  onRowDelete(plz: Plz) {
    delete this.plzs[plz.plz_Id];
  }

  showDialog(){
    this.displayDialog = true;
  }
}
