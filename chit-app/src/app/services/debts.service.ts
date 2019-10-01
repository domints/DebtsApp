import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DebtsService {

  constructor(private http: HttpClient) { }

  public getDebts(): Observable<{}> {
    return this.http.get('/api/debts');
  }
}
