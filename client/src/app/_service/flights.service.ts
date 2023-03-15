import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, tap, Observable, timer, share } from 'rxjs';
import { Flight } from '../_models/flight';

@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  basicUrl = "https://localhost:5001/api/flight"
  flightsSource = new BehaviorSubject<Flight[] | null>(null);
  currentFlights$ = this.flightsSource.asObservable();


  constructor(private http:HttpClient) { }

  getFlights(): Observable<Flight[]> {
    return this.http.get<Flight[]>(this.basicUrl).pipe(
      map((response:Flight[]) => {
        this.flightsSource.next(response);
        return response;
      })
    );
  }

  addFlight(model: Flight) {
    return this.http.post<Flight>("https://localhost:5001/api/Flight/add", model).pipe(
      map((response: Flight) => {
        const flightsFromSource = this.flightsSource.getValue();
        flightsFromSource?.push(response);
        if(flightsFromSource) {
          console.log(this.flightsSource.getValue())
          this.flightsSource.next(flightsFromSource);     
        }
      })
    )
  }

  deleteFlight(id: number) {
    return this.http.delete<Flight>(this.basicUrl + "/" + id).pipe(
      map( response => {
        const flightsFromSource = this.flightsSource.getValue()
        flightsFromSource?.forEach((flight, index) => {
          if(flight.flightId == response.flightId) flightsFromSource.splice(index, 1)
        })
      })
    )
  }

  autoRefreshFlights(timeInSeconds: number) {
    timeInSeconds = (timeInSeconds * 1000)
    return timer(0, timeInSeconds)
    .pipe(
      map( () => this.getFlights().subscribe()),
      share()
    )
  }
}
