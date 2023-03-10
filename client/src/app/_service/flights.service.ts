import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable } from 'rxjs';
import { Flight } from '../_models/flight';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  basicUrl = "https://localhost:5001/api/flight"
  currentFlightSource = new BehaviorSubject<Flight | null>(null);
  currentFlight$ = this.currentFlightSource.asObservable();


  constructor(private http:HttpClient) { }

  getFlights(): Observable<Flight[]> {
    return this.http.get<Flight[]>(this.basicUrl).pipe(
      map(response => {return response})
    );
  }

  addFlight(model: any) {
    return this.http.post<Flight>("https://localhost:5001/api/Flight/add", model).pipe(
      map((response: Flight) => {
        const flight = response;
        if(flight) {
          this.currentFlightSource.next(flight);
        }
      })
    );    
  }

  setCurrentFlight(flight: Flight) {
    this.currentFlightSource.next(flight);
  }

  deleteFlight(id: number) {
    return this.http.delete(this.basicUrl + "/" + id).pipe(
      map( response => {
        console.log(response);
      })
    )
  }
}
