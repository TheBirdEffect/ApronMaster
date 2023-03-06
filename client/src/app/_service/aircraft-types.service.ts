import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { AircraftType } from '../_models/aircraftType';

@Injectable({
  providedIn: 'root'
})
export class AircraftTypesService {
  baseUrl = "https://localhost:5001/api";

  constructor(private http:HttpClient) { }

  GetAircraftTypes() {
    return this.http.get<AircraftType>(this.baseUrl + "/AircraftType");
  }
}
