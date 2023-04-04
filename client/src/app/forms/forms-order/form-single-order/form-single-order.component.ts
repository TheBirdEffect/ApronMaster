import { formatCurrency } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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

  formArray = new FormArray([
    this.formBuilder.group({
      flight: ['', Validators.required],
      vehicleType: ['', Validators.nullValidator],
      position: ['', Validators.required],
      startOfService: ['', Validators.required],
      endOfService: ['', Validators.required],
      fuel: ['NULL', Validators.nullValidator],
      fuelAmmount: ['', Validators.nullValidator]
    })
  ]);

  flights$: Observable<Flight[] | null>;
  flight$: Observable<Flight | null>;
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
    this.positions$ = this.positionService.loadPositions();
    this.flight$ = this.flightService.loadFlight();
  }

  onSubmit() {
    console.log(this.formArray.value);
    console.log(this.formArray.valid);
  }

  newSingleForm() {
    const form = this.formBuilder.group({
      flight: ['', Validators.required],
      vehicleType: ['', Validators.nullValidator],
      position: ['', Validators.required],
      startOfService: ['', Validators.required],
      endOfService: ['', Validators.required],
      fuel: ['NULL', Validators.nullValidator],
      fuelAmmount: ['', Validators.nullValidator]
    }) as FormGroup
    this.formArray.push(form);
  }

  updateAircraftTypeByFlight() {

  }

  cancel() {
    this.closeModal.emit(true)
  }

}
