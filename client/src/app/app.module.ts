import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsFlightComponent } from './forms/forms-flight/forms-flight.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AlertModule } from 'ngx-bootstrap/alert';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { NgApexchartsModule } from 'ng-apexcharts';
import { DatePipe } from '@angular/common';
import { TableOrderComponent } from './tables/table-order/table-order.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableFlightComponent } from './tables/table-flight/table-flight.component';
import { AirportDataComponent } from './airport-data/airport-data.component';
import { PreferencesComponent } from './preferences/preferences.component';
import { AboutComponent } from './about/about.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { TableOrdersGroupComponent } from './tables/table-order/table-orders-group/table-orders-group.component';
import { TableOrdersDetailComponent } from './tables/table-order/table-orders-detail/table-orders-detail.component';
import { FlightsTabComponent } from './tabs/flights-tab/flights-tab.component';
import { OrdersTabComponent } from './tabs/orders-tab/orders-tab.component';
import { VehiclesTabComponent } from './tabs/vehicles-tab/vehicles-tab.component';
import { AircraftsTabComponent } from './tabs/aircrafts-tab/aircrafts-tab.component';
import { PreselectorOrderComponent } from './_modalTemplates/preselector-order/preselector-order.component';
import { FormCollectionOrderComponent } from './forms/forms-order/form-collection-order/form-collection-order.component';
import { FormSingleOrderComponent } from './forms/forms-order/form-single-order/form-single-order.component';
import { FormCollectionOrderDetailComponent } from './forms/forms-order/form-collection-order/form-collection-order-detail/form-collection-order-detail.component';
import { GroundVehicleScheduleComponent } from './charts/dashboard/ground-vehicle-schedule/ground-vehicle-schedule.component';
import { GoogleChartsModule } from 'angular-google-charts';
import { Ng2GoogleChartsModule } from 'ng2-google-charts';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    DashboardComponent,
    FormsFlightComponent,
    TableOrderComponent,
    TableFlightComponent,
    AirportDataComponent,
    PreferencesComponent,
    AboutComponent,
    PageNotFoundComponent,
    TableOrdersGroupComponent,
    TableOrdersDetailComponent,
    FlightsTabComponent,
    OrdersTabComponent,
    VehiclesTabComponent,
    AircraftsTabComponent,
    PreselectorOrderComponent,
    FormCollectionOrderComponent,
    FormSingleOrderComponent,
    FormCollectionOrderDetailComponent,
    GroundVehicleScheduleComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    AlertModule.forRoot(),
    TabsModule.forRoot(),
    PopoverModule.forRoot(),
    NgApexchartsModule,
    Ng2GoogleChartsModule,    
    BrowserAnimationsModule,
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
