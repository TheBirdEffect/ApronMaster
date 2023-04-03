import { formatCurrency } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Flight } from 'src/app/_models/flight';
import { position } from 'src/app/_models/position';
import { vehicleType } from 'src/app/_models/vehicleType';
import { FlightsService } from 'src/app/_service/flights.service';
import { PositionService } from 'src/app/_service/position.service';
import { VehicleService } from 'src/app/_service/vehicle.service';

@Component({
  selector: 'app-form-single-order',
  templateUrl: './form-single-order.component.html',
  styleUrls: ['./form-single-order.component.scss']
})
export class FormSingleOrderComponent implements OnInit {
  @Output() closeModal = new EventEmitter();

  singleOrderForm: FormGroup;
  formArray: FormArray;
  flights$: Observable<Flight[] | null>;
  vehicleTypes$: Observable<vehicleType[] | null>;
  positions$: Observable<position[] | null>;

  //https://blog.angular-university.io/angular-form-array/

  constructor(private flightService: FlightsService
    , private vehicleTypeService: VehicleService
    , private positionService: PositionService
    , private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.positionService.getPositions().subscribe();
    this.vehicleTypeService.GetVehicleTypes().subscribe();

    this.vehicleTypes$ = this.vehicleTypeService.loadVehicles();
    this.flights$ = this.flightService.loadFlights();
    this.positions$ = this.positionService.loadPositions()

    this.singleOrderForm = this.formBuilder.group({
      orders: this.formBuilder.array([])
    })
  }

  onSubmit(form: FormGroup<any>) {
    //console.log('Order Object', this.singleOrderForm.value);
  }

  get orders() {
    return this.singleOrderForm.controls['orders'] as FormArray;
  }

  newSingleForm() {
    const orderForm = this.formBuilder.group({
      flight: ['', Validators.required],
      vehicleType: ['', Validators.nullValidator],
      position: ['', Validators.required],
      startOfService: ['', Validators.required],
      endOfService: ['', Validators.required],
      fuel: ['NULL', Validators.nullValidator],
      fuelAmmount: ['', Validators.nullValidator]
    })

    this.orders.push(orderForm);
  }

  updateAircraftTypeByFlight() {

  }

  cancel() {
    this.closeModal.emit(true)
  }

}
