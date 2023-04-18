import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { stateObservablesEnum } from 'src/app/_enums/stateObservablesEnum';
import { OrderCollectionFormData, vehicleOrderTimeSet } from 'src/app/_models/DTOs/OrderCollectionDto';
import { Flight } from 'src/app/_models/flight';
import { position } from 'src/app/_models/position';
import { turnarroundVehicleTimeOffset } from 'src/app/_models/turnarroundVehicleTimeOffset';
import { vehicleType } from 'src/app/_models/vehicleType';
import { ModalService } from 'src/app/_service/modal.service';
import { OrderService } from 'src/app/_service/order.service';
import { StateService } from 'src/app/_service/state.service';
import { TurnarroundPresetService } from 'src/app/_service/turnarround-preset.service';
import { VehicleTimeOffsetService } from 'src/app/_service/vehicle-time-offset.service';
import { VehicleService } from 'src/app/_service/vehicle.service';

@Component({
  selector: 'app-form-collection-order-detail',
  templateUrl: './form-collection-order-detail.component.html',
  styleUrls: ['./form-collection-order-detail.component.scss']
})
export class FormCollectionOrderDetailComponent implements OnInit, OnDestroy {
  vehicleOffsetUpdateForm: FormGroup;
  vehicleOffsetArray = new FormArray([
    this.formBuilder.group({
      tvtoId: ['', Validators.nullValidator],
      vehicleTypeId: ['', Validators.required],
      timeOffsetStart: [0, Validators.required],
      timeOffsetEnd: [0, Validators.required],
      timeStart: [new Date(), Validators.nullValidator],
      timeEnd: [new Date(), Validators.nullValidator],
      fuelAmmount: ['', Validators.nullValidator],
      flight: [new Flight(), Validators.nullValidator],
      position: ['', Validators.nullValidator]
    })
  ]);

  vehicleArray = new Array<vehicleType>()
  flight: Flight;
  position: position;
  fuelAmmount: number;
  fuelType: string;

  orderCollectionFormData$: Observable<OrderCollectionFormData | null>;
  startTimeBelowArrivalSource = new BehaviorSubject<boolean>(false);
  endTimeAboveDepartureSource = new BehaviorSubject<boolean>(false);
  stateOffsetDataLoaded$: Observable<boolean>;



  __orderCollectionFormData: Subscription;
  __stateOffsetData: Subscription;

  constructor(private formBuilder: FormBuilder
    , private turnarroundPresetsService: TurnarroundPresetService
    , private vehicleTimeOffsetService: VehicleTimeOffsetService
    , private vehicleTypeService: VehicleService
    , private stateService: StateService
    , private orderService: OrderService
    , private modalService: ModalService) {
  }

  timeStartBelowArrival(index: number): boolean{
    const flight = this.vehicleOffsetArray.at(index).get('flight')?.value;
    const arrival = flight?.arrival as Date
    const timeStart = this.vehicleOffsetArray.at(index).get('timeStart')?.value! as Date

    console.log('ARRIVAL :' + arrival + ' TIMESTART: ' + timeStart);
    

    if(timeStart < arrival) {
      console.log('TimeStart < Arrival');
      return true;
    } else {
      return false;
    }

  }

  ngOnInit(): void {
    this.orderCollectionFormData$ = this.turnarroundPresetsService.loadOrderCollectionFormData();
    this.__orderCollectionFormData = this.orderCollectionFormData$.subscribe()
    this.stateOffsetDataLoaded$ = this.stateService.getStateObservable(
      stateObservablesEnum.ORDER_COLLECTION_TIME_OFFSET_LOADED
    )
    this.__stateOffsetData = this.stateOffsetDataLoaded$.subscribe();

    //this.vehicleOffsetArray = this.formBuilder.array([])

    //Get orderCollectionData from 'form-collection-order-component after pressing generate button
    this.generateOffsetList();
  }

  ngOnDestroy(): void {
    this.vehicleOffsetArray.clear();
    this.stateService.setStateObservable(
      stateObservablesEnum.ORDER_COLLECTION_TIME_OFFSET_LOADED, false
    )
    this.turnarroundPresetsService.ClearOrderCollectionFormData();
    this.__orderCollectionFormData.unsubscribe;
    this.__stateOffsetData.unsubscribe;
  }

  generateOffsetList() {
    this.orderCollectionFormData$.subscribe({
      next: (response) => {
        if (response) {
          this.vehicleOffsetArray.clear();
          this.vehicleArray = [];
          this.flight = response.flight;
          this.position = response.position;
          response.turnarroundPreset.turnarroundVehicleTimeOffsets
            .forEach((vehicleOffset: turnarroundVehicleTimeOffset, index) => {
              this.vehicleTypeService.GetVehicleType(
                vehicleOffset.vehicleTypeId
              ).subscribe(response => {
                this.vehicleArray[index] = response
              })
              this.newVehicleOffsetForm(vehicleOffset);
            })

          if (response.fuel !== 'NULL') {
            this.fuelAmmount = response.fuelAmmount;
            this.fuelType = response.fuel;
            this.vehicleTimeOffsetService.GetRefulingTimeOffset().subscribe((response) => {
              this.vehicleTypeService.GetVehicleType(
                response.vehicleTypeId
              ).subscribe(vehResponse => {
                this.vehicleArray.push(vehResponse)
              })
              this.newVehicleOffsetForm(response);
            })
          }

          if (response.checkPushback) {
            this.vehicleTimeOffsetService.GetPushbackTimeOffset().subscribe(response => {
              this.vehicleTypeService.GetVehicleType(
                response.vehicleTypeId
              ).subscribe(vehResponse => {
                this.vehicleArray.push(vehResponse)
              })
              this.newVehicleOffsetForm(response);
            })
          }

          if (response.checkService) {
            this.vehicleTimeOffsetService.GetServiceTimeOffset().subscribe(response => {
              response.forEach(offset => {
                this.vehicleTypeService.GetVehicleType(
                  offset.vehicleTypeId
                ).subscribe(vehResponse => {
                  this.vehicleArray.push(vehResponse)
                })
                this.newVehicleOffsetForm(offset);
              })
            })
          }
          setTimeout(() => {
            this.stateService.setStateObservable(
              stateObservablesEnum.ORDER_COLLECTION_TIME_OFFSET_LOADED, true
            )
          }, 200)
        }
      }
    });
  }

  setStartAndEndTime(givenFlight: Flight, timeOffsetStart: number, timeOffsetEnd: number): vehicleOrderTimeSet {
    let flight = new Flight();
    let timeSet = new vehicleOrderTimeSet();

    flight = givenFlight;
    let arrival = flight.arrival as Date;
    let departure = flight.departure as Date

    //Convert UNIX DateTime to TypeScript DateTime Object
    const arrivalTime = new Date(arrival);
    const departureTime = new Date(departure);

    timeOffsetStart = timeOffsetStart
    timeOffsetEnd = timeOffsetEnd;

    let currentStart: any;
    let currentEnd: any;

    console.log('TimeOffsetStart ' + timeOffsetStart + ' TimeOffsetEnd ' + timeOffsetEnd);
    
    
    if (timeOffsetStart < 0) {
      currentStart = departureTime.setMinutes(departureTime.getMinutes() + timeOffsetStart);
      currentEnd = departureTime.setMinutes(departureTime.getMinutes() + timeOffsetEnd);      
    } else {
      currentStart = arrivalTime.setMinutes(arrivalTime.getMinutes() + timeOffsetStart);
      currentEnd = arrivalTime.setMinutes(arrivalTime.getMinutes() + timeOffsetEnd);
    }

    const returnedStart = new Date(currentStart);
    const returnedEnd = new Date(currentEnd);

    console.log('StartCurrent: ' + currentStart + ' EndCurrent: ' + currentEnd);
    console.log('StartTime: ' + returnedStart + ' EndTime: ' + returnedEnd);

    timeSet.startTime = returnedStart;
    timeSet.endTime = returnedEnd;

    return timeSet;
  }

  detectChange(form: FormGroup, index: any) {
    let flight = new Flight();
    flight = form.get('flight')?.value

    let latestTimeStart = new Date(flight.arrival);
    let latestTimeEnd = new Date(flight.departure);

    let timeOffsetStart = form.get('timeOffsetStart')?.value as number;
    let timeOffsetEnd = form.get('timeOffsetEnd')?.value as number;

    let currentTimeStart: any;
    let currentTimeEnd: any;

    if (timeOffsetStart < 0) {
      currentTimeStart = latestTimeEnd.setMinutes(
        latestTimeEnd.getMinutes() + timeOffsetStart
      )
      currentTimeEnd = latestTimeEnd.setMinutes(
        (latestTimeEnd.getMinutes() + timeOffsetEnd) - timeOffsetStart
      )
    } else {
      currentTimeStart = latestTimeStart.setMinutes(
        latestTimeStart.getMinutes() + timeOffsetStart
      )
      currentTimeEnd = latestTimeStart.setMinutes(
        (latestTimeStart.getMinutes() + timeOffsetEnd) - timeOffsetStart
      )
    }

    const returnedStart = new Date(currentTimeStart)
    const returnedEnd = new Date(currentTimeEnd)

    let newForm = this.vehicleOffsetArray.at(index);
    newForm?.get('timeStart')?.setValue(returnedStart);
    newForm?.get('timeEnd')?.setValue(returnedEnd);
  }

  newVehicleOffsetForm(offsetData: turnarroundVehicleTimeOffset) {
    let form = this.formBuilder.group({
      tvtoId: ['', Validators.nullValidator],
      vehicleTypeId: ['', Validators.required],
      timeOffsetStart: ['', Validators.required],
      timeOffsetEnd: ['', Validators.required],
      timeStart: [new Date(), Validators.nullValidator],
      timeEnd: [new Date(), Validators.nullValidator],
      fuelAmmount: ['', Validators.nullValidator],
      fuelType: ['', Validators.nullValidator],
      flight: ['', Validators.nullValidator],
      position: ['', Validators.nullValidator]
    }) as FormGroup;

    form.get('flight')?.setValue(this.flight);
    form.get('position')?.setValue(this.position);
    if (offsetData.vehicleTypeId == 9) {
      form.get('fuelAmmount')?.setValue(this.fuelAmmount);
      form.get('fuelType')?.setValue(this.fuelType);
    } else {
      form.get('fuelAmmount')?.setValue(0);
      form.get('fuelType')?.setValue(0);
    }

    let timeSets = this.setStartAndEndTime(
      this.flight
      , offsetData.timeOffsetStart
      , offsetData.timeOffsetEnd
    );

    form.get('timeStart')?.setValue(timeSets.startTime);
    form.get('timeEnd')?.setValue(timeSets.endTime);

    form.patchValue(offsetData);

    this.vehicleOffsetArray.push(form);
  }

  onSubmit() {
    let finalVehicleOffsetArrray = new Array();
    for (let offset of this.vehicleOffsetArray.controls) {
      if (offset instanceof FormGroup) {
        if (offset.value.vehicleTypeId) {
          finalVehicleOffsetArrray.push(offset.value);
        }
      }
    }
    console.log(finalVehicleOffsetArrray);
    this.orderService.SetOrderCollection(finalVehicleOffsetArrray)
      .subscribe();
    this.modalService.closeModal();
  }

  closeModal() {
    this.modalService.closeModal();
  }
}
