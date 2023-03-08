import { Injectable } from '@angular/core';
import { AlertComponent } from 'ngx-bootstrap/alert';

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  alerts: any[] = []

  constructor() { }

  throwDatabaseAlert(type: string, dbTable: string): void {
    this.alerts.push({
      type: type,
      msg: 'Entry successfully added ' + dbTable + ' Database!',
      timeout: 3000
    })
  }

  onClosed(dismissedAlert: AlertComponent): void {
    this.alerts = this.alerts.filter(alert => alert !== dismissedAlert);
  }
}
