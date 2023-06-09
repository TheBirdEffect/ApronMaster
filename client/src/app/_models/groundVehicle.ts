import { position } from "./position";
import { vehicleType } from "./vehicleType";

export class groundVehicle
{
    groundVehicleId: number;
    name: string;
    isIdling: boolean;
    vehicleTypeId: number;
    vehicleType: vehicleType;
    positionId: number;
    position: position;
}