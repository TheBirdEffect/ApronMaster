import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { turnarroundVehicleTimeOffset } from '../_models/turnarroundVehicleTimeOffset';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleTimeOffsetService {

  constructor(private http: HttpClient) { }

  basicUrl = "https://localhost:5001/api/VehicleTimeOffset"

  // GetRefulingTimeOffset() {
  //   // return this.http.get<turnarroundVehicleTimeOffset>(this.basicUrl + '/get/refuling').subscribe({
  //   //   next: (response: turnarroundVehicleTimeOffset) => {
  //   //     return response;
  //   //   }
  //   // })
  // }

  GetRefulingTimeOffset() {
    return this.http.get<turnarroundVehicleTimeOffset>(this.basicUrl + '/get/refuling').pipe(
      map( response => {
        return response;
      })
    )
  }
  
  GetServiceTimeOffset() {
    return this.http.get<turnarroundVehicleTimeOffset[]>(this.basicUrl + '/get/service').pipe(
      map( response => {
        return response;
      })
    )
  }

  GetPushbackTimeOffset() {
    return this.http.get<turnarroundVehicleTimeOffset>(this.basicUrl + '/get/pushback').pipe(
      map( response => {
        return response;
      })
    )
  }
}
