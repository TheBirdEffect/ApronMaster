import { DatePipe } from "@angular/common";
import { AircraftType } from "./aircraftType";

export class Flight {
    flightId: number;
    flightNumber: string;
    arrival: Date;
    departure: Date;
    destination: string;
    aircraftTypeId: number;
    aircraftType: AircraftType;
}