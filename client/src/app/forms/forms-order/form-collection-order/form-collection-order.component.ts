import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { stateObservablesEnum } from 'src/app/_enums/stateObservablesEnum';
import { AircraftTypeIdAndPosCaracteristics } from 'src/app/_models/DTOs/OrderCollectionDto';
import { aircraftTurnarroundPreset } from 'src/app/_models/aircraftTurnarroundPreset';
import { AircraftType } from 'src/app/_models/aircraftType';
import { Flight } from 'src/app/_models/flight';
import { position } from 'src/app/_models/position';
import { AircraftTypesService } from 'src/app/_service/aircraft-types.service';
import { FlightsService } from 'src/app/_service/flights.service';
import { PositionService } from 'src/app/_service/position.service';
import { StateService } from 'src/app/_service/state.service';
import { TurnarroundPresetService } from 'src/app/_service/turnarround-preset.service';

@Component({
  selector: 'app-form-collection-order',
  templateUrl: './form-collection-order.component.html',
  styleUrls: ['./form-collection-order.component.scss']
})
export class FormCollectionOrderComponent implements OnInit {
  @Output() closeModal = new EventEmitter();

  collectionForm: FormGroup;

  flights$: Observable<Flight[] | null>;
  aircraftType$: Observable<AircraftType | null>;
  positions$: Observable<position[] | null>;
  presets$: Observable<aircraftTurnarroundPreset[] | null>;


  constructor(private formBuilder: FormBuilder,
    private flightService: FlightsService,
    private positionService: PositionService,
    private aircraftTypeService: AircraftTypesService,
    private turnarroundPresetsService: TurnarroundPresetService,
  ) { }

  ngOnInit(): void {
    this.positionService.getPositions().subscribe();
    this.flights$ = this.flightService.loadFlights();
    this.positions$ = this.positionService.loadPositions()
    this.presets$ = this.turnarroundPresetsService.loadPresets();


    this.collectionForm = this.formBuilder.group({
      flight: ['', Validators.required],
      aircraftType: ['', Validators.nullValidator],
      position: ['', Validators.required],
      turnarroundPreset: ['', Validators.required],
      checkService: [false, Validators.nullValidator],
      checkPushback: [false, Validators.nullValidator],
      fuel: ['NULL', Validators.nullValidator],
      fuelAmmount: ['', Validators.nullValidator]
    })

  }

  get turnarroundPreset(): FormControl {
    return this.collectionForm.get('turnarroundPreset') as FormControl;
  }

  get turnarroundPresetValue(): aircraftTurnarroundPreset {
    return this.collectionForm.value['turnarroundPreset'];
  }

  updateAircraftTypeByFlight() {
    this.aircraftTypeService.GetAircraftType(
      this.collectionForm.value.flight.aircraftTypeId
    ).subscribe();
    this.aircraftType$ = this.aircraftTypeService.loadAircraftType();

    if (this.collectionForm.value['position'] != "") {
      this.updateTurnarroundPreset();
    }
  }

  updateTurnarroundPreset() {
    var aTandPos = new AircraftTypeIdAndPosCaracteristics;
    var position = this.collectionForm.value['position'];
    var aircraftType = this.aircraftTypeService.typeSource.getValue();


    if (aircraftType) {
      aTandPos.aircraftTypeId = aircraftType.aircraftTypeId;
      aTandPos.utilizeGangways = position.isGate;
      this.turnarroundPresetsService
        .GetTempForAircraftTypeFilteredByPosCharacteristics(aTandPos).subscribe({
          next: response => console.log(response)
        });
    }
  }



  onSubmit(form: FormGroup) {

  }

  onCalculate() {
    this.turnarroundPresetsService.SetOrderCollectionFormData(this.collectionForm.value);    
  }

  cancel() {
    this.closeModal.emit(true)
  }
}
