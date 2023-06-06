import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { VehicleService } from './vehicle.service';
import { vehicleSchedule } from '../_models/vehicleSchedule';

@Injectable({
  providedIn: 'root'
})
export class SchedulingTableService {
  private basicApiPath = "https://localhost:5001/api/VehicleSchedule";

  private schedulingTableDataSource = new BehaviorSubject<vehicleSchedule[] | null>(null);
  currentSchedulingTableData$ = this.schedulingTableDataSource.asObservable();

  constructor(
    public http: HttpClient
    ) { }

  public getExtendedVehicleScheduling(): Observable<vehicleSchedule[]> {
    return this.http.get<vehicleSchedule[]>(this.basicApiPath + "/extended").pipe(
      map( response => {
        this.schedulingTableDataSource.next(response);
        return response;
      })
    )
  }

  public deleteSchedules() {
    return this.http.delete(this.basicApiPath + "/all").subscribe();
  }

  public setSchedulingDataSource(schedule: vehicleSchedule[]){
    this.schedulingTableDataSource.next(schedule);
  }

  public loadSchedulingTableData() {
    return this.currentSchedulingTableData$;
  }
}
