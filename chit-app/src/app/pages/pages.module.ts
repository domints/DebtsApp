import { NgModule } from '@angular/core';
import { NbMenuModule, NbCardModule, NbButtonModule } from '@nebular/theme';

import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { NotFoundComponent } from './not-found/not-found.component';
import { ThemeModule } from '../@theme/theme.module';
import { SummaryComponent } from './summary/summary.component';

@NgModule({
  imports: [
    PagesRoutingModule,
    ThemeModule,
    NbMenuModule,
    NbCardModule,
    NbButtonModule,
  ],
  declarations: [
    NotFoundComponent,
    SummaryComponent,
    PagesComponent,
  ],
})
export class PagesModule {
}
