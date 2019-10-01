import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SummaryComponent } from './summary/summary.component';
import { ListComponent } from './list/list.component';
import { ContactsComponent } from './contacts/contacts.component';
import { AddContactComponent } from './add-contact/add-contact.component';

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
      children: [
        {
          path: 'add',
          component: AddContactComponent
        },
        {
          path: '',
          component: ContactsComponent
        }
      ]
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
