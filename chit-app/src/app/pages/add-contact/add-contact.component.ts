import { NbMenuService } from '@nebular/theme';
import { Component, OnInit } from '@angular/core';
import { DebtsService } from 'src/app/services/debts.service';
import { ContactsService, Contact } from 'src/app/services/contacts.service';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-add-contact',
  styleUrls: ['./add-contact.component.scss'],
  templateUrl: './add-contact.component.html',
})
export class AddContactComponent implements OnInit {

  contact: Contact = new Contact();
  isError: boolean = false;
  
  constructor(
    private contactsService: ContactsService,
    private router: Router) {
  }

  ngOnInit() {
  }

  save() {
    this.contactsService.addContact(this.contact).subscribe({error: () => this.isError = true, next: () => this.router.navigate(['/app','contacts'])});
  }
}
