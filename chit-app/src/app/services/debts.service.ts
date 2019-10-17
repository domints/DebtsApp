import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DebtsService {

  constructor(private http: HttpClient) { }

  public gridDebts(url: string, parameters?: { [param: string]: string | string[] }): Observable<Debt[]> {
    return this.http.get<Debt[]>(url, { params: parameters} );
  }

  public static allDebts: string = '/api/debts';
}

export class Debt {
  id: number;
  value: number;
  description: number;
  isMyDebt: boolean;
  isEditable: boolean;
  otherId: number;
  otherName: string;
}
