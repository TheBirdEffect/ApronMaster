import { Component, Input, ViewChild, OnInit, OnChanges, SimpleChanges} from '@angular/core';

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexYAxis,
  ApexXAxis,
  ApexDataLabels,
  ApexGrid
} from "ng-apexcharts";
import { BehaviorSubject } from 'rxjs';
import { Flight } from 'src/app/_models/flight';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  yaxis: ApexYAxis;
  dataLabels: ApexDataLabels;
  grid: ApexGrid;
};


@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.scss']
})
export class FlightsComponent implements OnInit{
  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions> | any;
  private _flights = new BehaviorSubject<any[]|null>(null);

  @Input() 
    set flightsFromDashboardComponent(value:any) {
      this._flights.next(value);
    };

    get flightsFromDashboardComponent() {
      return this._flights.getValue()
    }
  
  constructor() {}
  
  ngOnInit(): void {
    this._flights.subscribe(async flights => {
      const _flight = flights?.at(0); 
      console.log(_flight);
      
      await this.generateTuples(flights?.at(0))
    })
  }

  private generateTuples(flights:any) {
    this.chartOptions = {

      series: [
        {
          name: flights.flightNo,
          data: this.generateDayWiseTimeSeries(
            new Date("11 Feb 2017 GMT").getTime(),
            20,
            {
              min: 10,
              max: 60
            }
          )
        },
        {
          name: "TEAM 2",
          data: this.generateDayWiseTimeSeries(
            new Date("11 Feb 2017 GMT").getTime(),
            20,
            {
              min: 10,
              max: 60
            }
          )
        },
        {
          name: "TEAM 3",
          data: this.generateDayWiseTimeSeries(
            new Date("11 Feb 2017 GMT").getTime(),
            30,
            {
              min: 10,
              max: 60
            }
          )
        },
        {
          name: "TEAM 4",
          data: this.generateDayWiseTimeSeries(
            new Date("11 Feb 2017 GMT").getTime(),
            10,
            {
              min: 10,
              max: 60
            }
          )
        },
        {
          name: "TEAM 5",
          data: this.generateDayWiseTimeSeries(
            new Date("11 Feb 2017 GMT").getTime(),
            30,
            {
              min: 10,
              max: 60
            }
          )
        }
      ],
      chart: {
        height: 350,
        type: "scatter",
        zoom: {
          type: "xy"
        }
      },
      dataLabels: {
        enabled: false
      },
      grid: {
        xaxis: {
          lines: {
            show: true
          }
        },
        yaxis: {
          lines: {
            show: true
          }
        }
      },
      xaxis: {
        type: "datetime"
      },
      yaxis: {
        max: 70
      }
    };
  }

  public generateDayWiseTimeSeries(baseval:any, count:any, yrange:any) {
    var i = 0;
    var series = [];
    while (i < count) {
      var y =
        Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;

      series.push([baseval, y]);
      baseval += 86400000;
      i++;
    }
    return series;
  }
  
  loadData() {
    console.log(this.flightsFromDashboardComponent);
    
  }
  
}
