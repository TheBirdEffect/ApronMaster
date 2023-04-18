import { formatCurrency } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Flight } from 'src/app/_models/flight';
import { position } from 'src/app/_models/position';
import { vehicleType } from 'src/app/_models/vehicleType';
import { FlightsService } from 'src/app/_service/flights.service';
import { ModalService } from 'src/app/_service/modal.service';
import { OrderService } from 'src/app/_service/order.service';
import { PositionService } from 'src/app/_service/position.service';
import { VehicleService } from 'src/app/_service/vehicle.service';

@Component({
  selector: 'app-form-single-order',
  templateUrl: './form-single-order.component.html',
  styleUrls: ['./form-single-order.component.scss']
})
export class FormSingleOrderComponent implements OnInit {

  formArray = new FormArray([
    this.formBuilder.group({
      flight: [new Flight(), Validators.required],
      vehicleType: ['', Validators.nullValidator],
      position: ['', Validators.required],
      startOfService: ['', Validators.required],
      endOfService: ['', Validators.required],
      fuel: ['NULL', Validators.nullValidator],
      fuelAmmount: [0, Validators.nullValidator]
    })
  ]);

  flights$: Observable<Flight[] | null>;
  vehicleTypes$: Observable<vehicleType[] | null>;
  positions$: Observable<position[] | null>;

  //https://blog.angular-university.io/angular-form-array/

  constructor(private flightService: FlightsService
    , private vehicleTypeService: VehicleService
    , private positionService: PositionService
    , private formBuilder: FormBuilder
    , private modalService: ModalService
    , private orderService: OrderService
  ) { }

  ngOnInit(): void {
    this.positionService.getPositions().subscribe();
    this.vehicleTypeService.GetVehicleTypes().subscribe();
    this.vehicleTypes$ = this.vehicleTypeService.loadVehicles();
    this.flights$ = this.flightService.loadOrderedFlights();
    this.positions$ = this.positionService.loadPositions();

    this.setChosenFlightAsSelected(this.formGroupOnArraysFirstPosition);
  }

  get formGroupOnArraysFirstPosition() {
    return this.formArray.at(0) as FormGroup
  }

  newSingleForm() {
    const form = this.formBuilder.group({
      flight: [new Flight(), Validators.required],
      vehicleType: ['', Validators.nullValidator],
      position: ['', Validators.required],
      startOfService: ['', Validators.required],
      endOfService: ['', Validators.required],
      fuel: ['NULL', Validators.nullValidator],
      fuelAmmount: [0, Validators.nullValidator]
    }) as FormGroup

    form.get('position')?.setValue(this.formGroupOnArraysFirstPosition.get('position')?.value)
    this.setChosenFlightAsSelected(form);
    this.formArray.push(form);
  }
  
  setChosenFlightAsSelected(formGroup: FormGroup) {
    this.flights$.subscribe(response => {
      if(response != null) {
        formGroup.get('flight')?.setValue(response.at(0)!);
        formGroup.get('startOfService')?.setValue(response.at(0)?.arrival)
        formGroup.get('endOfService')?.setValue(response.at(0)?.departure)
      } else {
        this.flights$ = this.flightService.loadFlights();
      }
    })
  }

  onSubmit() {
    let finalFormArray = new Array();
    for(let order of this.formArray.controls) {
      if(order instanceof FormGroup) {
        finalFormArray.push(order.value);
      }
    }
    this.orderService.SetSingleOrders(finalFormArray)
      .subscribe();
    this.closeModal();
  }
  
  closeModal() {
    this.modalService.closeModal();
  }

}
