import { Flight } from "./flight";
import { position } from "./position";
import { vehicleType } from "./vehicleType";

export interface order {
    orderId: number;
    startOfService: Date;
    endOfService: Date;
    qtyFuel: number;
    position: position;
    flight: Flight;
    vehicleType: vehicleType;
}