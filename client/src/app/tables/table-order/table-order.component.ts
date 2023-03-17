import { trigger, state, style, animate, transition } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { accordeonData } from 'src/app/_models/accordeonData';
import { Flight } from 'src/app/_models/flight';
import { order } from 'src/app/_models/order';
import { position } from 'src/app/_models/position';
import { vehicleType } from 'src/app/_models/vehicleType';
import { AircraftTypesService } from 'src/app/_service/aircraft-types.service';
import { FlightsService } from 'src/app/_service/flights.service';
import { OrderService } from 'src/app/_service/order.service';
import { PositionService } from 'src/app/_service/position.service';
import { VehicleService } from 'src/app/_service/vehicle.service';

@Component({
  selector: 'app-table-order',
  templateUrl: './table-order.component.html',
  styleUrls: ['./table-order.component.scss'],
})
export class TableOrderComponent implements OnInit {

  constructor(private flightservice: FlightsService,
    private vehicleService: VehicleService,
    private positionService: PositionService,
    private orderService: OrderService) { 
    }

  ngOnInit(): void {     
  }


}
