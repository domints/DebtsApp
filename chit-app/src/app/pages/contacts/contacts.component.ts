import { Component, OnInit } from '@angular/core';
import { ContactsService, Contact } from 'src/app/services/contacts.service';

@Component({
  selector: 'ngx-contacts',
  styleUrls: ['./contacts.component.scss'],
  templateUrl: './contacts.component.html',
})
export class ContactsComponent implements OnInit {

  contacts: Contact[] = [];
  constructor(private contactsService: ContactsService) {
  }

  ngOnInit() {
    this.contactsService.getContacts().subscribe({ next: (val) => this.contacts = val });
  }
}
