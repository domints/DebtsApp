import { NbMenuService } from '@nebular/theme';
import { Component, OnInit } from '@angular/core';
import { DebtsService, Debt } from 'src/app/services/debts.service';
import { LocalDataSource } from 'ng2-smart-table';
import { throwIfAlreadyLoaded } from 'src/app/@core/module-import-guard';

@Component({
  selector: 'ngx-list',
  styleUrls: ['./list.component.scss'],
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {

  url: string = DebtsService.allDebts;
  constructor(private debtsService: DebtsService) {
  }

  ngOnInit() {
    
  } 
}
