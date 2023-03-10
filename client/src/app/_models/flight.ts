import { DatePipe } from "@angular/common";
import { AircraftType } from "./aircraftType";

export interface Flight {
    flightNumber: String;
    arrival: Date;
    departure: Date;
    destination: String;
    aircraftType: AircraftType;
}