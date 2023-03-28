import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';
import { Observable, of, Subscription, } from 'rxjs';
import { FlightsService } from '../../_service/flights.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AlertService } from '../../_service/alert.service';
import { Flight } from '../../_models/flight';
import { OrderService } from 'src/app/_service/order.service';

@Component({
  selector: 'app-table-flight',
  templateUrl: './table-flight.component.html',
  styleUrls: ['./table-flight.component.scss']
})
export class TableFlightComponent implements OnInit {
  @Input() editMode = true;

  registerMode = false;
  modalRef?: BsModalRef;
  flights$: Observable<Flight[] | null> = of(null);
  flights: any;
  subscription: Subscription;

  //Properties for UpdateMode
  flightToUpdate: Flight;
  responsedFlight: any;

  constructor(public flightService: FlightsService,
    private modalService: BsModalService,
    private orderService: OrderService
  ) { }

  ngOnInit(): void {
    this.getFlights();
    //console.log(this.editMode);

    //this.flightService.autoRefreshFlights(30).subscribe();
  }

  getFlights() {
    return this.flightService.getFlights().subscribe({
      next: response => {
        this.flights = response
        console.log(this.flights);
        
      },
      error: error => console.log(error)
    })
  }

  getFullFlightById(id: number) {
    this.flightService.getFullFlightByID(id).subscribe({
      next: (response: Flight) => { 
        // const flight = new Flight();

        // flight.aircraftType = response.aircraftType;
        // flight.aircraftTypeId = response.aircraftTypeId;
        // flight.arrival = response.arrival;
        // flight.departure = response.departure;
        // flight.destination = response.destination;
        // flight.flightId = response.flightId,
        // flight.flightNumber = response.flightNumber;

        return response;         
      }
    });
  }

  updateFlight(flight: Flight){     
    this.flightService.getFullFlightByID(flight.flightId).subscribe(
      (response: Flight) => this.flightService.flightSource.next(response)
    );
  }

  deleteFlight(flightId: number): void {
    this.flightService.deleteFlight(flightId).subscribe()
  }


  //modal
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  closeModal() {
    this.modalRef?.hide();
  }

  toggleFormMode() {
    this.registerMode = !this.registerMode;
  }

  cancelFormMode(event: boolean) {
    this.registerMode = event;
    this.closeModal()
  }

  transmitChosenFlightForOrders(flight: Flight) {
    this.orderService.GetOrdersOfFlight(flight).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => console.log(error)
      
    })
  }


}


