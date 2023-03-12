import { Flight } from "./flight";
import { position } from "./position";
import { vehicleType } from "./vehicleType";

export class order {
    orderId: number;
    startOfService: Date;
    endOfService: Date;
    qtyFuel: number;
    positionId: number;
    position: position;
    flightId: number;
    flight: Flight;
    vehicleTypeId: number;
    vehicleType: vehicleType;
}