import { Component, OnInit } from '@angular/core';
import { ContactsService, Contact } from 'src/app/services/contacts.service';

@Component({
  selector: 'ngx-contacts',
  styleUrls: ['./contacts.component.scss'],
  templateUrl: './contacts.component.html',
})
export class ContactsComponent implements OnInit {

  isError: boolean = false;
  contacts: ContactViewModel[] = [];
  constructor(private contactsService: ContactsService) {
  }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.contactsService.getContacts().subscribe({ next: (val) => this.contacts = val.sort((a, b) => (a.name > b.name) ? 1 : -1).map(c => <ContactViewModel>c) });
  }

  addNew() {
    let newContact = new ContactViewModel();
    newContact.isNew = true;
    newContact.isEditing = true;
    newContact.balance = 0;
    this.contacts.unshift(newContact);
  }

  setEdit(contact: ContactViewModel)
  {
    contact.isEditing = true;
    contact.originalName = contact.name;
  }

  resetEdit(contact: ContactViewModel)
  {
    if(contact.isNew)
    {
      this.contacts.shift();
    }
    else {
      contact.name = contact.originalName;
      contact.isEditing = false;
    }
  }

  deleteContact(contact: ContactViewModel) {
    this.contactsService.deleteContact(<Contact>contact).subscribe({ error: this.showError.bind(this), next: this.refresh.bind(this)});
  }

  saveContact(contact: ContactViewModel) {
    contact.isEditing = false;
    if(contact.isNew) {
      this.contactsService.addContact(<Contact>contact).subscribe({ error: this.showError.bind(this), next: this.refresh.bind(this)});
      this.contacts = this.contacts.sort((a, b) => (a.name > b.name) ? 1 : -1);
    }
    else {
      this.contactsService.saveContact(<Contact>contact).subscribe({ error: this.showError.bind(this)});
    }
    contact.isNew = false;
  }

  showError() {
    this.isError = true;
    setTimeout(() => this.isError = false, 5000);
  }
}

export class ContactViewModel extends Contact {
  originalName: string;
  isEditing: boolean;
  isNew: boolean;
}
