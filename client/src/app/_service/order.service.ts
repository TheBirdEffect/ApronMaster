import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { Flight } from '../_models/flight';
import { order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private basicApiPath = "https://localhost:5001/api"
  _ordersSource = new BehaviorSubject<order[] | null>(null);
  currentOrders$ = this._ordersSource.asObservable();

  private _ordersOfFlight = new BehaviorSubject<order[] | null>(null);
  currentOrdersOfFlight$ = this._ordersOfFlight.asObservable();

  constructor(private http: HttpClient) { }

  GetOrders():Observable<order[]> {
    return this.http.get<order[]>(this.basicApiPath + "/order").pipe(
      map(response => {
        this._ordersSource.next(response)
        return response;
      })
    )
  }

  GetOrdersOfFlight(flight: Flight) {
    console.log(flight);
    return this.http.get<order[]>(this.basicApiPath + "/order/flight" + flight?.flightId).pipe(
      map(response => {
        this._ordersOfFlight.next(response);
        return response;
      })
    )
  }

  /*
    Getter and setter to set BehaviorSubjects
  */

  /*
    BehaviorSubject _flightForOrder
  */

}
