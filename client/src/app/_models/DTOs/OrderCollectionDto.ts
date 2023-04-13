import { aircraftTurnarroundPreset } from "../aircraftTurnarroundPreset";
import { AircraftType } from "../aircraftType";
import { Flight } from "../flight";
import { position } from "../position";

export class AircraftTypeIdAndPosCaracteristics
{
    aircraftTypeId: number;
    //aircraftType: AircraftType; TODO: UNCOMMENT if database table TEMPLATES extended by unitLoad option
    utilizeGangways: boolean;
}

export class OrderCollectionFormData {
    flight: Flight;
    aircraftType: AircraftType;
    position: position;
    turnarroundPreset: aircraftTurnarroundPreset;
    checkService: boolean;
    checkPushback: boolean;
    fuel: string;
    fuelAmmount: number;
}