import { Component, OnInit, Input } from '@angular/core';
import { Debt } from 'src/app/services/debts.service';

@Component({
  selector: 'debt-line-item',
  templateUrl: './debt-line-item.component.html',
  styleUrls: ['./debt-line-item.component.scss']
})
export class DebtLineItemComponent implements OnInit {

  @Input()
  item: Debt;

  constructor() { }

  ngOnInit() {
  }

}
