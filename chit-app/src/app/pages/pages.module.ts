import { NgModule } from '@angular/core';
import { NbMenuModule, NbCardModule, NbButtonModule, NbIconModule, NbAlertModule, NbListModule } from '@nebular/theme';

import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { ThemeModule } from '../@theme/theme.module';
import { SummaryComponent } from './summary/summary.component';
import { ListComponent } from './list/list.component';
import { ContactsComponent } from './contacts/contacts.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    PagesRoutingModule,
    ThemeModule,
    FormsModule,
    NbMenuModule,
    NbCardModule,
    NbButtonModule,
    NbIconModule,
    NbAlertModule,
    NbListModule
  ],
  declarations: [
    NotFoundComponent,
    PagesComponent,
    SummaryComponent,
    ListComponent,
    ContactsComponent
  ],
})
export class PagesModule {
}
