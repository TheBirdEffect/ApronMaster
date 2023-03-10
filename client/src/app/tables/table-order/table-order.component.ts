import { Component } from '@angular/core';
import { Flight } from 'src/app/_models/flight';
import { position } from 'src/app/_models/position';
import { vehicleType } from 'src/app/_models/vehicleType';
import { AircraftTypesService } from 'src/app/_service/aircraft-types.service';
import { FlightsService } from 'src/app/_service/flights.service';
import { PositionService } from 'src/app/_service/position.service';
import { VehicleService } from 'src/app/_service/vehicle.service';

@Component({
  selector: 'app-table-order',
  templateUrl: './table-order.component.html',
  styleUrls: ['./table-order.component.scss']
})
export class TableOrderComponent {
  private _postitions: position[];
  private _flights: Flight[];
  private _vehicleTypes: vehicleType[];
  private _orders: any = {}

  constructor(private flightservice:FlightsService,
              private vehicleService: VehicleService,
              private positionService:PositionService) {}

  GetPositions() {
    return this.positionService.getPositions().subscribe({
      next: res => {
        this._postitions = res;        
      },
      error: error => console.log(error)          
    });
  }

  GetFlights() {
    return this.flightservice.getFlights().subscribe({
      next: res => {
        this._flights = res;
      },
      error: error => console.log(error),
      complete: () => console.log(this._flights[0])
    })
  }

  GetVehicleTypes() {
    return this.vehicleService.GetVehicleType().subscribe({
      next: res => {
        this._vehicleTypes = res;
      },
      error: error => console.log(error),
      complete: () => console.log(this._vehicleTypes[0])
      
    })
  }
}
