import { groundVehicle } from "./groundVehicle";
import { order } from "./order";

export class vehicleSchedule
{
    scheduleId: number;
    groundVehicleId: number;
    groundVehicle: groundVehicle;
    orderId: number;
    order: order;
}