import { DatePipe } from "@angular/common";
import { AircraftType } from "./aircraftType";

export interface Flight {
    flightNumber: String;
    arrival: String;
    departure: String;
    destination: String;
    aircraftType: AircraftType;
}