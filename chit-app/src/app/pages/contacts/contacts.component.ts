import { Component, OnInit } from '@angular/core';
import { ContactsService } from 'src/app/services/contacts.service';

@Component({
  selector: 'ngx-contacts',
  styleUrls: ['./contacts.component.scss'],
  templateUrl: './contacts.component.html',
})
export class ContactsComponent implements OnInit {

  constructor(private contactsService: ContactsService) {
  }

  ngOnInit() {
    this.contactsService.getContacts().subscribe({ next: (val) => console.log(val) });
  }
}
