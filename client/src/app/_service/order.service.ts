import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { order } from '../_models/order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private basicApiPath = "https://localhost:5001/api"

  constructor(private http: HttpClient) { }

  GetOrders():Observable<order[]> {
    return this.http.get<order[]>(this.basicApiPath + "/order").pipe(
      map(res => {return res})
    )
  }
}
