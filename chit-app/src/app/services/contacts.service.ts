import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(private http: HttpClient) { }

  public getContacts(): Observable<Contact> {
    return this.http.get<Contact>('/api/contacts');
  }

  public addContact(c: Contact): Observable<{}> {
    return this.http.post('/api/contacts', c);
  }
}

export class Contact {
  id: number;
  name: string;
  isChitUser: string;
  balance: number;
}
