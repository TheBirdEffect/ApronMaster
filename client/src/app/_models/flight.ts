import { DatePipe } from "@angular/common";
import { AircraftType } from "./aircraftType";

export class Flight {
    flightId: number;
    flightNumber: String;
    arrival: Date;
    departure: Date;
    destination: String;
    aircraftType: AircraftType;
}