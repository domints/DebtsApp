import { Component, OnInit, Input } from '@angular/core';
import { Debt, DebtsService } from 'src/app/services/debts.service';
import { NbWindowService, NbWindowRef } from '@nebular/theme';
import { DebtEditorComponent } from '../debt-editor/debt-editor.component';

@Component({
  selector: 'debt-grid',
  templateUrl: './debt-grid.component.html',
  styleUrls: ['./debt-grid.component.scss'],
  host: {'class': 'w-100'}
})
export class DebtGridComponent implements OnInit {

  @Input()
  dataUrl: string;
  @Input()
  parameters: { [param: string]: string | string[] } | undefined;

  items: DebtLineItem[] = [];

  addWindow: NbWindowRef;

  constructor(
    private debtService: DebtsService,
    private windowService: NbWindowService) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.debtService.gridDebts(this.dataUrl, this.parameters).subscribe({ next: (val) => this.items = val.map(v => <DebtLineItem>v)});
  }
  
  addNew() {
    this.addWindow = this.windowService.open(DebtEditorComponent, { title: "Add debt" });
  }
}

export class DebtLineItem extends Debt {

}
