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
  private _postitions: position[];
  private _flights: Flight[];
  private _vehicleTypes: vehicleType[];
  public _orders: order[];

  _accordeonData = new Array<accordeonData>;

  constructor(private flightservice: FlightsService,
    private vehicleService: VehicleService,
    private positionService: PositionService,
    private orderService: OrderService) { 
    }

  ngOnInit(): void {  
    this.GetFlights();
    this.GetVehicleTypes();
    this.GetPositions();  
    this.GetOrders();    
  }

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
      complete: () => {
        this.SetToggleOptions()
        console.log(this._accordeonData);
        
      }
    })
  }

  GetVehicleTypes() {
    return this.vehicleService.GetVehicleTypes().subscribe({
      next: res => {
        this._vehicleTypes = res;
      },
      error: error => console.log(error)
    })
  }

  GetOrders() {
    return this.orderService.GetOrders().subscribe({
      next: res => {
        this._orders = res;
      },
      error: error => console.log(error),
      complete: () => {
        this._orders.forEach(order => {
          order.position = this._postitions[order.positionId-1]
          order.flight = this._flights[order.flightId-1]
          order.vehicleType = this._vehicleTypes[order.vehicleTypeId-1];
        })
      }
    })
  }

  SetToggleOptions() {
    let flights = this.flightservice.flightsSource.getValue();
    if(flights) {
      flights.forEach(flight => {
        const data = new accordeonData;
        data.name = flight?.flightNumber;
        data.isCollapsed = false;
        console.log(data);
        
        this._accordeonData.push(data);
      })
    }
  }

  expandRow(accData: accordeonData) {
    accData;
    this._accordeonData.forEach(data => {
      if(accData.name == data.name) {
        accData.isCollapsed = !accData.isCollapsed;
        //console.log(this._accordeonData);
        
      }

    })
  }

}
