import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { stateObservablesEnum } from 'src/app/_enums/stateObservablesEnum';
import { OrderCollectionFormData } from 'src/app/_models/DTOs/OrderCollectionDto';
import { turnarroundVehicleTimeOffset } from 'src/app/_models/turnarroundVehicleTimeOffset';
import { vehicleType } from 'src/app/_models/vehicleType';
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
      timeOffsetStart: ['', Validators.required],
      timeOffsetEnd: ['', Validators.required]
    })
  ]);

  vehicleArray = new Array<vehicleType>()

  orderCollectionFormData$: Observable<OrderCollectionFormData | null>;
  stateOffsetDataLoaded$: Observable<boolean>;

  __orderCollectionFormData: Subscription;
  __stateOffsetData: Subscription;

  constructor(private formBuilder: FormBuilder
    , private turnarroundPresetsService: TurnarroundPresetService
    , private vehicleTimeOffsetService: VehicleTimeOffsetService
    , private vehicleTypeService: VehicleService
    , private stateService: StateService) { }

  ngOnInit(): void {
    this.orderCollectionFormData$ = this.turnarroundPresetsService.loadOrderCollectionFormData();
    this.__orderCollectionFormData = this.orderCollectionFormData$.subscribe()
    this.stateOffsetDataLoaded$ = this.stateService.getStateObservable(
      stateObservablesEnum.ORDER_COLLECTION_TIME_OFFSET_LOADED
    )
    this.__stateOffsetData = this.stateOffsetDataLoaded$.subscribe();

    //this.vehicleOffsetArray = this.formBuilder.array([])

    //Get orderCollectionData from 'form-collection-order-component after pressing generate button
    this.orderCollectionFormData$.subscribe({
      next: (response) => {
        console.log('Response: ', response);

        if (response) {
          this.vehicleOffsetArray.clear();
          this.vehicleArray = [];
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
          }, 500)
        }
      }
    });
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

  newVehicleOffsetForm(offsetData: turnarroundVehicleTimeOffset) {
    let form = this.formBuilder.group({
      tvtoId: ['', Validators.nullValidator],
      vehicleTypeId: ['', Validators.required],
      timeOffsetStart: ['', Validators.required],
      timeOffsetEnd: ['', Validators.required]
    }) as FormGroup;

    form.patchValue(offsetData);
    this.vehicleOffsetArray.push(form);
  }

  onSubmit() {
    let finalVehicleOffsetArrray = new Array<turnarroundVehicleTimeOffset>();
    for (let offset of this.vehicleOffsetArray.controls) {
      if (offset instanceof FormGroup) {
        let vehicleTimeOffset = new turnarroundVehicleTimeOffset();
        vehicleTimeOffset.vehicleTypeId = offset.value.vehicleTypeId?
      }
    }
  }

}
