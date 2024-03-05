import { turnarroundVehicleTimeOffset } from "./turnarroundVehicleTimeOffset";

export class aircraftTurnarroundPreset
{
    presetId: number;
    name: string;
    utilizeGangways: boolean;
    descriptionNotes: string;
    turnarroundVehicleTimeOffsets: turnarroundVehicleTimeOffset[]; 
}