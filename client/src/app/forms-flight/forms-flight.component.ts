import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { AircraftType } from '../_models/aircraftType';
import { Flight } from '../_models/flight';
import { AircraftTypesService } from '../_service/aircraft-types.service';
import { FlightsService } from '../_service/flights.service';

@Component({
  selector: 'app-forms-flight',
  templateUrl: './forms-flight.component.html',
  styleUrls: ['./forms-flight.component.scss']
})
export class FormsFlightComponent implements OnInit {
  aircraftTypes: any;
  model: any = {}


  constructor(private flightService: FlightsService, private aircrafttypeService: AircraftTypesService) { }

  ngOnInit(): void {
    this.getAircraftTypes();

  }

  addFlight() {
    this.flightService.addFlight(this.model).subscribe({
      next: subscribe => {
        this.model = subscribe
      }, 
      error: error => console.log(error)
    });
  }

  getAircraftTypes() {
    this.aircrafttypeService.GetAircraftTypes().subscribe({
      next: response => {
        this.aircraftTypes = response;
      }
    })
  }

}
