import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { vehicleType } from '../_models/vehicleType';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  private vehicleSource = new BehaviorSubject<vehicleType[] | null>(null);
  public lastFetchedVehicles$ = this.vehicleSource.asObservable();

  basicApiPath = "https://localhost:5001/api"
  constructor(private http: HttpClient) { }

  GetVehicleTypes(): Observable<vehicleType[]> {
    return this.http.get<vehicleType[]>(this.basicApiPath + "/vehicletype").pipe(
      map(res => { 
        this.vehicleSource.next(res);  
        return res 
      })
    )
  }

  GetVehicleType(id: number): Observable<vehicleType> {
    return this.http.get<vehicleType>(this.basicApiPath + "/vehicletype/" + id).pipe(
      map(res => { return res })
    )
  }

  loadVehicles() {
    return this.lastFetchedVehicles$;
  }
}


