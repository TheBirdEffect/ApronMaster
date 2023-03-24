import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { first, map } from 'rxjs';
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
  @Output() cancelForm = new EventEmitter();

  id: number;
  form: FormGroup
  title = "Flight";


  constructor(private flightService: FlightsService,
    public aircrafttypeService: AircraftTypesService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.getAircraftTypes();
    this.id = this.route.snapshot.params['id'];

    this.form = this.formBuilder.group({
      flightNumber: ['', Validators.required],
      arrival: ['', Validators.required],
      departure: ['', Validators.required],
      destination: ['', Validators.required],
      aircraftType: ['', Validators.required]
    });
  }

  //https://jasonwatmore.com/post/2022/12/05/angular-14-dynamic-add-edit-form-that-supports-create-and-update-mode#users-add-edit-component-ts
  // Hier gehts weiter

  get f() { return this.form.controls; }



  addFlight(model: any) {
    this.flightService.addFlight(model).subscribe({
      next: response => {
        //this.model = response
      },
      error: error => console.log(error)
    });
  }

  getAircraftTypes() {
    this.aircrafttypeService.GetAircraftTypes().subscribe({
      next: response => {
        //this.aircraftTypes = response;
      }
    })
  }

  onSubmit(form: FormGroup) {
    const flight = this.mapFlight(form);    
    this.addFlight(flight);
    this.cancel()
  }
  mapFlight(form: FormGroup): Flight {
    return form.value;
  }

  cancel() {
    this.cancelForm.emit(false);
  }

}
