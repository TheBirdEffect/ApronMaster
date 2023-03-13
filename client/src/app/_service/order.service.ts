import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { accordeonData } from '../_models/accordeonData';
import { order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private basicApiPath = "https://localhost:5001/api"
  _ordersSource = new BehaviorSubject<order[] | null>(null);
  currentOrders$ = this._ordersSource.asObservable();

  _accordeonDataSource = new BehaviorSubject<accordeonData[] | null>(null);
  currentAccordeonData$ = this._accordeonDataSource.asObservable();


  constructor(private http: HttpClient) { }

  GetOrders():Observable<order[]> {
    return this.http.get<order[]>(this.basicApiPath + "/order").pipe(
      map(response => {
        this._ordersSource.next(response)
        return response;
      })
    )
  }
}
