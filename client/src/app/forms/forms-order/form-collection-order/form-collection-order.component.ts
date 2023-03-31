import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { AircraftType } from 'src/app/_models/aircraftType';
import { Flight } from 'src/app/_models/flight';
import { position } from 'src/app/_models/position';
import { AircraftTypesService } from 'src/app/_service/aircraft-types.service';
import { FlightsService } from 'src/app/_service/flights.service';
import { PositionService } from 'src/app/_service/position.service';

@Component({
  selector: 'app-form-collection-order',
  templateUrl: './form-collection-order.component.html',
  styleUrls: ['./form-collection-order.component.scss']
})
export class FormCollectionOrderComponent implements OnInit{

  collectionForm: FormGroup;
  flights$: Observable<Flight[] | null>;
  aircraftType$: Observable<AircraftType | null>;
  positions$: Observable<position[] | null>;

  constructor(private formBuilder: FormBuilder,
              private flighService: FlightsService,
              private positionService: PositionService,
              private aircraftTypeService: AircraftTypesService
              ) {}

  ngOnInit(): void {
    this.positionService.getPositions().subscribe();
    this.flights$ = this.flighService.loadFlights();
    this.positions$ = this.positionService.loadPositions()


    this.collectionForm = this.formBuilder.group({
      flight: ['', Validators.required],
      aircraftType: ['', Validators.nullValidator],
      position: ['', Validators.required],
      fuel: ['NULL', Validators.nullValidator],
      fuelAmmount: ['', Validators.nullValidator]
    })
  }

  updateAircraftTypeByFlight() {
    this.aircraftTypeService.GetAircraftType(
      this.collectionForm.value.flight.aircraftTypeId
    ).subscribe();
    this.aircraftType$ = this.aircraftTypeService.loadAircraftType();
  }

  onSubmit(form: FormGroup) {
    console.log(this.collectionForm.value);
  }

  cancel() {}
}
