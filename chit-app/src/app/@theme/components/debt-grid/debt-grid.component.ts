import { Component, OnInit, Input } from '@angular/core';
import { Debt } from 'src/app/services/debts.service';

@Component({
  selector: 'debt-grid',
  templateUrl: './debt-grid.component.html',
  styleUrls: ['./debt-grid.component.scss']
})
export class DebtGridComponent implements OnInit {

  @Input()
  items: Debt[] = [];

  constructor() { }

  ngOnInit() {
  }

}
