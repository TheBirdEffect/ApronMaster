import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AirportDataComponent } from './airport-data/airport-data.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PreferencesComponent } from './preferences/preferences.component';

const routes: Routes = [
  { path: '/dashboard', component: DashboardComponent},
  { path: '/airportdata', component:  AirportDataComponent},
  { path: '/preferences', component: PreferencesComponent},
  { path: '/about', component: AboutComponent},
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
