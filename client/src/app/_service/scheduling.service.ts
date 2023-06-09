import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SchedulingTableService } from './scheduling-table.service';
import { vehicleSchedule } from '../_models/vehicleSchedule';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SchedulingService {

  private basicApiPath = "https://localhost:5001/api/Schedule";

  constructor(public http: HttpClient, public schedulingTableService: SchedulingTableService) { }



  public initializeScheduling() {
    return this.http.get(this.basicApiPath + "/inititialize").subscribe();
  }

  public initiateScheduling() {
    return this.http.get(this.basicApiPath + "/schedule").subscribe();
  }

  public updateScheduling() {
    return this.http.get<vehicleSchedule[]>(this.basicApiPath + "/updateSchedule").pipe(
      map((response: vehicleSchedule[]) => {
        this.schedulingTableService.setSchedulingDataSource(response);
        return response;
      })
    );
  }
}
