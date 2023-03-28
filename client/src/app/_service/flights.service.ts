import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, map, tap, Observable, timer, share, delay } from 'rxjs';
import { FilterEnum } from '../_enums/FilterEnum';
import { SortEnum } from '../_enums/SortEnum';
import { Flight } from '../_models/flight';


@Injectable({
  providedIn: 'root'
})
export class FlightsService {
  basicUrl = "https://localhost:5001/api/flight"
  flightsSource = new BehaviorSubject<Flight[] | null>(null);
  currentFlights$ = this.flightsSource.asObservable();

  flightSource = new BehaviorSubject<Flight | any>(null);
  currentFlight$ = this.flightSource.asObservable();

  constructor(private http: HttpClient) { }

  getFlights(): Observable<Flight[]> {
    return this.http.get<Flight[]>(this.basicUrl).pipe(
      map((response: Flight[]) => {
        let flights: Flight[] = response;
        flights = this.filterFlights(flights, FilterEnum.everything);
        flights = this.sortFlights(flights, SortEnum.increase);
        this.flightsSource.next(flights);
        return response;
      })
    );
  }

  getFlightById(id: number): Observable<Flight> {
    return this.http.get<Flight>(this.basicUrl + "/" + id);
  }

  getFullFlightByID(id: number): Observable<Flight> {
    return this.http.get<Flight>(this.basicUrl + "/full/" + id).pipe(
      map((response: Flight) => {
        return response;
      })
    )
  }

  addFlight(model: Flight) {
    return this.http.post<Flight>("https://localhost:5001/api/Flight/add", model).pipe(
      map((response: Flight) => {
        let flightsFromSource = this.flightsSource.getValue();
        flightsFromSource?.push(response);
        if (flightsFromSource) {
          flightsFromSource = this.sortFlights(flightsFromSource, SortEnum.increase)
          this.flightsSource.next(flightsFromSource);
        }
      })
    )
  }

  updateFlight(model: Flight) {
    return this.http.post<Flight>(this.basicUrl + "/update", model).pipe(
      map((response: Flight) => {        
        console.log('UpdateMethodContainedFlight', model)
        let flightsFromSource = this.flightsSource.getValue();
        flightsFromSource?.forEach((flight, index) => {
          if (flight == response) {
            flightsFromSource?.splice(index, 1, response);
          }
        })
        if (flightsFromSource) {
          flightsFromSource = this.sortFlights(flightsFromSource, SortEnum.increase)
          this.flightsSource.next(flightsFromSource);
        }
      })
    )
  }

  deleteFlight(id: number) {
    return this.http.delete<Flight>(this.basicUrl + "/" + id).pipe(
      map(response => {
        const flightsFromSource = this.flightsSource.getValue()
        flightsFromSource?.forEach((flight, index) => {
          if (flight.flightId == response.flightId) flightsFromSource.splice(index, 1)
        })
      })
    )
  }

  autoRefreshFlights(timeInSeconds: number) {
    timeInSeconds = (timeInSeconds * 1000)
    return timer(0, timeInSeconds)
      .pipe(
        map(() => this.getFlights().subscribe()),
        share()
      )
  }

  sortFlights(flights: Flight[], kindOfSort: SortEnum): Flight[] {
    if (kindOfSort === SortEnum.increase) {
      return flights.sort((a, b) => {
        return <any>new Date(a.arrival) - <any>new Date(b.arrival);
      })
    } else {
      return flights.sort((a, b) => {
        return <any>new Date(b.arrival) - <any>new Date(a.arrival);
      })
    }
  }

  filterFlights(flights: Flight[], filterEnum: FilterEnum): Flight[] {
    const now = new Date();
    if (filterEnum === FilterEnum.onlyCurrent) {
      const newFlightsArray: Flight[] = [];
      flights.forEach(flight => {
        if (<any>new Date(flight.arrival) > now) {
          newFlightsArray.push(flight);

        }
      })
      return newFlightsArray;
    }
    return flights;
  }

  loadFlight() {
    return this.currentFlight$.pipe(
    );
  }
}