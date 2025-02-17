import { Component, OnInit, TemplateRef } from '@angular/core';
import { Observable, of, Subscription, } from 'rxjs';
import { FlightsService } from '../_service/flights.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AlertService } from '../_service/alert.service';
import { Flight } from '../_models/flight';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  // registerMode = false;
  // modalRef?: BsModalRef;
  // flights$:Observable<Flight[] | null> = of(null);
  // flights: any;
  // subscription: Subscription;

  constructor(public flightService: FlightsService,
    // private modalService: BsModalService,
    // private alertService: AlertService
  ) { }


  ngOnInit(): void {
    //this.getFlights();
  }

  // getFlights() {
  //   return this.flightService.getFlights().subscribe({
  //     next: response => {
  //       this.flights = response
  //     },
  //     error: error => console.log(error)
  //   })
  // }


  // deleteFlight(flightId: number): void {
  //   this.flightService.deleteFlight(flightId).subscribe()
  // }


  // //modal
  // openModal(template: TemplateRef<any>) {
  //   this.modalRef = this.modalService.show(template);
  // }

  // closeModal() {
  //   this.modalRef?.hide();
  // }

  // toggleFormMode() {
  //   this.registerMode = !this.registerMode;
  // }

  // cancelFormMode(event: boolean) {
  //   this.registerMode = event;
  //   this.closeModal()
  // }


}
