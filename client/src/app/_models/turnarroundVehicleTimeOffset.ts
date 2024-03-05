import { aircraftTurnarroundPreset } from "./aircraftTurnarroundPreset";
import { vehicleType } from "./vehicleType";

export class turnarroundVehicleTimeOffset
{
    tvtoId: number;
    timeOffsetStart: number;
    timeOffsetEnd: number;
    aircraftTurnarroundPreset: aircraftTurnarroundPreset
    vehicleTypeId: number;
    vehicleType: vehicleType;
}