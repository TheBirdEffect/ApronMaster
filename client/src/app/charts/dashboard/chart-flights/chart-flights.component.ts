import { DatePipe } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import * as moment from "moment";
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexPlotOptions,
  ApexXAxis,
  ApexFill,
  ApexDataLabels,
  ApexYAxis,
  ApexGrid
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  fill: ApexFill;
  dataLabels: ApexDataLabels;
  grid: ApexGrid;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  plotOptions: ApexPlotOptions;
};

@Component({
  selector: 'app-chart-flights',
  templateUrl: './chart-flights.component.html',
  styleUrls: ['./chart-flights.component.scss']
})
export class ChartFlightsComponent {
  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions> | any;

  constructor(private datepipe: DatePipe) {
    console.log(new DatePipe('en-US').transform("2023-02-14T14:45:00", 'h:mm:ss a'));
    

    this.chartOptions = {
      series: [
        {
          data: [
            {
              x: "Analysis",
              y: [
                new DatePipe('en-US').transform("2023-02-14T14:00:00", 'h:mm:ss a'),
                new DatePipe('en-US').transform("2023-02-14T14:45:00", 'h:mm:ss a'),
              ],
              fillColor: "#008FFB"
            },
            // {
            //   x: "Design",
            //   y: [
            //     new Date("2019-03-04").getTime(),
            //     new Date("2019-03-08").getTime()
            //   ],
            //   fillColor: "#00E396"
            // },
            // {
            //   x: "Coding",
            //   y: [
            //     new Date("2019-03-07").getTime(),
            //     new Date("2019-03-10").getTime()
            //   ],
            //   fillColor: "#775DD0"
            // },
            // {
            //   x: "Testing",
            //   y: [
            //     new Date("2019-03-08").getTime(),
            //     new Date("2019-03-12").getTime()
            //   ],
            //   fillColor: "#FEB019"
            // },
            // {
            //   x: "Deployment",
            //   y: [
            //     new Date("2019-03-12").getTime(),
            //     new Date("2019-03-17").getTime()
            //   ],
            //   fillColor: "#FF4560"
            // }
          ]
        }
      ],
      chart: {
        height: 350,
        type: "rangeBar"
      },
      plotOptions: {
        bar: {
          horizontal: true,
          distributed: true,
          dataLabels: {
            hideOverflowingLabels: false
          }
        }
      },
      dataLabels: {
        enabled: true,
        formatter: function(val: any, opts: any) {
          var label = opts.w.globals.labels[opts.dataPointIndex];
          var a = moment(val[0]);
          var b = moment(val[1]);
          var diff = b.diff(a, "hours");
          return label + ": " + diff + (diff > 1 ? " minutes" : " hours");
        },
        style: {
          colors: ["#f3f4f5", "#fff"]
        }
      },
      xaxis: {
        type: "datetime",
        labels: {
          datetimeFormatter: {
            hour: 'HH:m'
          }
        }
      },
      yaxis: {
        show: false
      },
      grid: {
        row: {
          colors: ["#f3f4f5", "#fff"],
          opacity: 1
        }
      }
    };
  }

}
