import { Component } from '@angular/core';

@Component({
  selector: 'app-ground-vehicle-schedule',
  templateUrl: './ground-vehicle-schedule.component.html',
  styleUrls: ['./ground-vehicle-schedule.component.scss']
})
export class GroundVehicleScheduleComponent {

  public timeLineChartData: any = {
    chartType: 'Timeline',
    dataTable: [
      ['Name', 'Flight', 'From', 'To'],
      [
        'Belt1',
        'LH2203',
        new Date(2023, 5, 4, 15, 0, 0, 0),
        new Date(2023, 5, 4, 15, 40, 0, 0),
      ],
      [
        'Belt1',
        'EZY1010',
        new Date(2023, 5, 4, 16, 0, 0, 0),
        new Date(2023, 5, 4, 16, 40, 0, 0),
      ],
      [
        'Belt2',
        'EZY1010',
        new Date(2023, 5, 4, 15, 5, 0, 0),
        new Date(2023, 5, 4, 15, 20, 0, 0),
      ],
      [
        'LuggTruck',
        'EZY1010',
        new Date(2023, 5, 4, 15, 0, 0, 0),
        new Date(2023, 5, 4, 15, 40, 0, 0),
      ],
    ],
  }
}
