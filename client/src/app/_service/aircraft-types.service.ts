import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { AircraftType } from '../_models/aircraftType';

@Injectable({
  providedIn: 'root'
})
export class AircraftTypesService {
  baseUrl = "https://localhost:5001/api";
  typesSource = new BehaviorSubject<AircraftType[] | null>(null);
  currentType$ = this.typesSource.asObservable();

  typeSource = new BehaviorSubject<AircraftType | null>(null);
  selectedType$ = this.typeSource.asObservable();

  constructor(private http: HttpClient) { }

  GetAircraftTypes() {
    return this.http.get<AircraftType[]>(this.baseUrl + "/AircraftType").pipe(
      map((response: AircraftType[]) => {
        this.typesSource.next(response);
      })
    );
  }

  GetAircraftType(id: number) {
    return this.http.get<AircraftType>(this.baseUrl + "/aircrafttype/" + id).pipe(
      map((response: AircraftType) => {
        this.typeSource.next(response);
      })
    );
  }

  loadAircraftType() {
    return this.selectedType$;
  }
}
