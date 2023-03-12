import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { BehaviorSubject, combineLatest, interval, startWith, switchMap } from 'rxjs';
import { FlightsService } from '../_service/flights.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AlertService } from '../_service/alert.service';
import * as ApexCharts from 'apexcharts';
import { Flight } from '../_models/flight';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  registerMode = false;
  modalRef?: BsModalRef;
  flights: any;

  constructor(private flightService: FlightsService,
    private modalService: BsModalService,
    private alertService: AlertService
  ) { }

  private readonly autoRefresh$ = interval(1000).pipe(
    startWith(0)
  );

  private readonly refreshFlights$ = new BehaviorSubject(undefined);
  private readonly flight$ = combineLatest(this.autoRefresh$, this.refreshFlights$).pipe(
    switchMap(() => this.flightService.getFlights())
  );

  //https://blog.eyas.sh/2018/12/data-and-page-content-refresh-patterns-in-angular/ hier gehts weiter


  ngOnInit(): void {
    this.getFlights();
  }

  getFlights(): any {
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

  deleteFlight(flightId: number): void {
    this.flightService.deleteFlight(flightId).subscribe();
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


}
