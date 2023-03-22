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

  SetOrder(order: order): Observable<order> {
    return this.http.post<order>(this.basicApiPath + "/order/add", order).pipe(
      map(response => {
        this.AddToObservableArray(response);
        console.log(this._ordersOfFlight.getValue());
        return response;
      })
    )
  }

  UpdateOrder(order: order): Observable<order> {
    return this.http.post<order>(this.basicApiPath + "/order/update", order).pipe(
      map(response => {
        const orders = this._ordersOfFlight.getValue();
        orders?.forEach((order, index) => {
          if(order.orderId == response.orderId) order = response;
        })
        this._ordersOfFlight.next(orders);
        return response;
      })
    )
  }

  DeleteOrder(id: number) {
    return this.http.delete<order>(this.basicApiPath + "/order/" + id).pipe(
      map( response => {
        const orders = this._ordersOfFlight.getValue();
        orders?.forEach((order, index) => {
          if(order.orderId == response.orderId) orders.splice(index, 1)
        })
      })
    )
  }


  AddToObservableArray(order: order) {
    const orders = this._ordersOfFlight.getValue();
    if(orders != null) {
      orders.push(order)
    }
    this._ordersSource.next(orders);
  }
  /*
    Getter and setter to set BehaviorSubjects
  */

}
