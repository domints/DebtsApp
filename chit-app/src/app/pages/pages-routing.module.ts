import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SummaryComponent } from './summary/summary.component';
import { ListComponent } from './list/list.component';
import { ContactsComponent } from './contacts/contacts.component';

const routes: Routes = [{
  path: '',
  component: PagesComponent,
  children: [
    {
      path: '404',
      component: NotFoundComponent,
    },
    {
      path: 'list',
      component: ListComponent
    },
    {
      path: 'contacts',
      component: ContactsComponent
    },
    {
      path: '',
      pathMatch: 'full',
      component: SummaryComponent
    },
    {
      path: '**',
      component: NotFoundComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
