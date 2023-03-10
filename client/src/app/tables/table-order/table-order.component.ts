import { Component } from '@angular/core';
import { AircraftTypesService } from 'src/app/_service/aircraft-types.service';
import { FlightsService } from 'src/app/_service/flights.service';
import { PositionService } from 'src/app/_service/position.service';

@Component({
  selector: 'app-table-order',
  templateUrl: './table-order.component.html',
  styleUrls: ['./table-order.component.scss']
})
export class TableOrderComponent {
  private _postitions:any = { };
  private _flights: any = { };
  private _vehicleTypes: any = { };
  private _orders: any = {}

  constructor(private flightservice:FlightsService,
              private aircraftTypeService:AircraftTypesService,
              private positionService:PositionService) {}

  GetPositions() {
    this.positionService.GetPosition().subscribe({
      next: response => {
        this._postitions = response;
        console.log(response);
        
      },
      error: error => console.log(error),
      complete: () => console.log("Positions successfully fetched")
    })
  }
}
