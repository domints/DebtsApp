import { NbMenuService } from '@nebular/theme';
import { Component, OnInit } from '@angular/core';
import { DebtsService } from 'src/app/services/debts.service';

@Component({
  selector: 'ngx-list',
  styleUrls: ['./list.component.scss'],
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {

  constructor(private debtsService: DebtsService) {
  }

  ngOnInit() {
    this.debtsService.getDebts().subscribe({ next: (val) => console.log(val) });
  }
}
