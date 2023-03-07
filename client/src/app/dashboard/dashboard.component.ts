import { Component, OnInit, TemplateRef } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { FlightsService } from '../_service/flights.service';
import { BsModalService}

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  flights: any;

  constructor(private flightService:FlightsService) { }

  ngOnInit(): void {
    this.getFlights();
  }

  getFlights():any {
    this.flightService.getFlights().subscribe({
      next: response => {
        this.flights = response
      },
      error: error => console.log(error)
    })
  }



  addFlight() {
    console.log('AddFlight')
  }

  deleteFlight(flightId:number): void {
    this.flightService.deleteFlight(flightId).subscribe();
  }





}
