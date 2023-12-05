import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { first, map, Observable, Subscription, tap } from 'rxjs';
import { AircraftType } from '../../_models/aircraftType';
import { Flight } from '../../_models/flight';
import { AircraftTypesService } from '../../_service/aircraft-types.service';
import { FlightsService } from '../../_service/flights.service';

@Component({
  selector: 'app-forms-flight',
  templateUrl: './forms-flight.component.html',
  styleUrls: ['./forms-flight.component.scss']
})
export class FormsFlightComponent implements OnInit {
  @Input() updateMode: boolean;
  @Output() cancelForm = new EventEmitter();

  aircraftTypes$: Observable<AircraftType[] | null>;
  flightToUpdate$: Observable<Flight>;
  currentAircraftType: AircraftType;
  __aircraftTypes: Subscription;

  id: number;
  flightForm: FormGroup
  title = "Flight";

  constructor(
    private flightService: FlightsService,
    public aircrafttypeService: AircraftTypesService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.aircrafttypeService.GetAircraftTypes().subscribe();
    this.aircraftTypes$ = this.aircrafttypeService.currentType$;

    this.flightForm = this.formBuilder.group({
      flightId: ['0', Validators.nullValidator],
      flightNumber: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      arrival: ['', Validators.required],
      departure: ['', Validators.required],
      destination: ['', Validators.required],
      aircraftTypeId: ['0', Validators.nullValidator],
      aircraftType: ['', Validators.required]
    });

    console.log("UMode: " + this.updateMode)
    // if (this.updateMode) {
    //   this.flightToUpdate$ = this.flightService.loadFlight().pipe(
    //     tap(flight => {        
    //       console.log("Flight to update: " + flight)
    //       this.flightForm.patchValue(flight)
    //     })
        
    //   )
    // }    
    if (this.updateMode) {
      this.flightToUpdate$ = this.flightService.loadFlight().pipe(
        tap(flight => {        
          console.log("Flight to update: " + flight)
          this.flightForm.patchValue(flight)
        })
      )
      this.flightToUpdate$.subscribe();
    }    
  }

  //https://jasonwatmore.com/post/2022/12/05/angular-14-dynamic-add-edit-form-that-supports-create-and-update-mode#users-add-edit-component-ts
  // Hier gehts weiter

  get f() { return this.flightForm.controls; }



  addFlight(model: any) {
    this.flightService.addFlight(model).subscribe({
      next: response => {
        //this.model = response
      },
      error: error => console.log(error)
    });
  }

  updateFlight(model: Flight) {
    console.log('ContentOfFlight@updateFlight', model);  
    this.flightService.updateFlight(model).subscribe({
    })
  }

  getAircraftType(id: number) {
    this.aircrafttypeService.GetAircraftType(id).subscribe();
  }

  onSubmit(form: FormGroup) {
    const flight = this.mapFlight(form);  
    if(this.updateMode) {
      console.log(flight);      
      this.updateFlight(flight)
      this.updateMode = !this.updateMode;
    } else {
      this.addFlight(flight);
    }
 
    this.cancel()
  }

  mapFlight(form: FormGroup): Flight {
    return form.value;
  }

  cancel() {
    this.cancelForm.emit(false);
    if(this.updateMode) {
      this.updateMode = !this.updateMode
    }
  }

}
