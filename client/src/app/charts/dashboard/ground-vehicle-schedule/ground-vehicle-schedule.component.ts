import { Component, OnDestroy, OnInit } from '@angular/core';
import { GoogleChartInterface } from 'ng2-google-charts';
import { BehaviorSubject, Observable, isObservable } from 'rxjs';
import { vehicleScheduleChartData } from 'src/app/_models/DTOs/vehicleScheduleChartData';
import { vehicleSchedule } from 'src/app/_models/vehicleSchedule';
import { SchedulingTableService } from 'src/app/_service/scheduling-table.service';
import { SchedulingService } from 'src/app/_service/scheduling.service';

@Component({
  selector: 'app-ground-vehicle-schedule',
  templateUrl: './ground-vehicle-schedule.component.html',
  styleUrls: ['./ground-vehicle-schedule.component.scss']
})
export class GroundVehicleScheduleComponent implements OnInit, OnDestroy {
  title = "Schedules";

  vehicleSchedules$: Observable<vehicleSchedule[] | null>;
  public timeLineChartData: GoogleChartInterface;

  constructor(private scheduleTableService: SchedulingTableService
            , private scheduleService: SchedulingService) { }

  ngOnInit(): void {
    //this.scheduleTableService.deleteSchedules();  
    //this.scheduleService.initializeScheduling();
    this.vehicleSchedules$ = this.scheduleTableService.loadSchedulingTableData();
    this.timeLineChartData = this.initializeChartData();
  }

  ngOnDestroy(): void {

  }

  public initializeBackend() {
    this.scheduleService.initiateScheduling();
  }

  public deleteData() {
    this.scheduleTableService.deleteSchedules();
  }

  public updateScheduling() {
    this.scheduleService.updateScheduling().subscribe();
    this.vehicleSchedules$ = this.scheduleTableService.loadSchedulingTableData();
    this.redrawChart();
  }

  public redrawChart() {
    let chartComponent = this.timeLineChartData.component!;
    let chartWrapper = chartComponent.wrapper;

    //force a redraw
    chartComponent.draw();
  }

  public initializeChartData() {
    let timeLineChartData: GoogleChartInterface = {
      chartType: 'Timeline',
      dataTable: this.mapSchedulingDataOnChart(),
      options: {
        height: 1000,
        isObservable: true
      }
    }
    return timeLineChartData;
  }

  public mapSchedulingDataOnChart() {
    let data = new Array<Array<string | Date>>();
    data.push(['Name', 'Flight', 'From', 'To']);
    this.vehicleSchedules$.subscribe(response => {
      //console.log("Response: ", response);
      
      response?.forEach(element => {
        const eSos = new Date(element.order.startOfService).toISOString();
        const deadline = new Date(element.order.endOfService).toISOString();
        data.push(new Array<string | Date>(
          element.groundVehicle.name
          , element.order.flight.flightNumber
          // , new Date(
          //   eSos.getFullYear()
          //   , eSos.getMonth()
          //   , eSos.getDay()
          //   , eSos.getHours()
          //   , eSos.getMinutes()
          //   , eSos.getSeconds()
          //   , eSos.getMilliseconds()
          // )
          , new Date(eSos)
          // , new Date(eSos.getFullYear()
          //   , deadline.getMonth()
          //   , deadline.getDay()
          //   , deadline.getHours()
          //   , deadline.getMinutes()
          //   , deadline.getSeconds()
          //   , deadline.getMilliseconds()
          // )
          , new Date(deadline)
        ))
      });
    });
    return data;
  }

  // public timeLineChartData: any = {
  //   chartType: 'Timeline',
  //   dataTable: [
  //     ['Name', 'Flight', 'From', 'To'],
  //     [
  //       'Belt1',
  //       'LH2203',
  //       new Date(2023, 5, 4, 15, 0, 0, 0),
  //       new Date(2023, 5, 4, 15, 40, 0, 0),
  //     ],
  //     [
  //       'Belt1',
  //       'EZY1010',
  //       new Date(2023, 5, 4, 16, 0, 0, 0),
  //       new Date(2023, 5, 4, 16, 40, 0, 0),
  //     ],
  //     [
  //       'Belt2',
  //       'EZY1010',
  //       new Date(2023, 5, 4, 15, 5, 0, 0),
  //       new Date(2023, 5, 4, 15, 20, 0, 0),
  //     ],
  //     [
  //       'LuggTruck',
  //       'EZY1010',
  //       new Date(2023, 5, 4, 15, 0, 0, 0),
  //       new Date(2023, 5, 4, 15, 40, 0, 0),
  //     ],
  //   ],
  // }
}
