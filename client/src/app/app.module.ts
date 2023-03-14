import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsFlightComponent } from './forms/forms-flight/forms-flight.component';
import { FormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AlertModule } from 'ngx-bootstrap/alert';
import { NgApexchartsModule } from 'ng-apexcharts';
import { ChartFlightsComponent } from './charts/dashboard/chart-flights/chart-flights.component';
import { DatePipe } from '@angular/common';
import { FormOrderComponent } from './forms/form-order/form-order.component';
import { TableOrderComponent } from './tables/table-order/table-order.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableFlightComponent } from './tables/table-flight/table-flight.component';
import { AirportDataComponent } from './airport-data/airport-data.component';
import { PreferencesComponent } from './preferences/preferences.component';
import { AboutComponent } from './about/about.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    DashboardComponent,
    FormsFlightComponent,
    ChartFlightsComponent,
    FormOrderComponent,
    TableOrderComponent,
    TableFlightComponent,
    AirportDataComponent,
    PreferencesComponent,
    AboutComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ModalModule.forRoot(),
    AlertModule.forRoot(),
    NgApexchartsModule,
    BrowserAnimationsModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
