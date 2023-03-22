import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { first } from 'rxjs';
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
  aircraftTypes: any;
  model: any = {}

  id: number;
  form!: FormGroup
  title = "Flight";
  loading = false;
  submitted = false;


  constructor(private flightService: FlightsService, 
              private aircrafttypeService: AircraftTypesService,
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

    this.title = 'Add Flight';
    if (this.id) {
      //edit mode
      this.title = 'Edit Flight';
      this.loading = true;
      this.flightService.getFlightById(this.id)
      .pipe(first())
      .subscribe(flight => {
        this.form.patchValue(flight);
        this.loading = false;
      })    
    }
  }

  //https://jasonwatmore.com/post/2022/12/05/angular-14-dynamic-add-edit-form-that-supports-create-and-update-mode#users-add-edit-component-ts
  // Hier gehts weiter

  addFlight() {
    this.flightService.addFlight(this.model).subscribe({
      next: response => {
        this.model = response
      }, 
      error: error => console.log(error),
      complete: () =>  {
        this.cancel()
      }
    });
  }

  getAircraftTypes() {
    this.aircrafttypeService.GetAircraftTypes().subscribe({
      next: response => {
        this.aircraftTypes = response;
      }
    })
  }

  onSubmit() {

  }

  cancel() {
    this.cancelForm.emit(false);
  }

}
