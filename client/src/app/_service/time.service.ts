import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, share, timer } from 'rxjs';
import { timeZoneMessage } from '../_models/messages/timeZoneMessage';

@Injectable({
  providedIn: 'root'
})
export class TimeService {
  private timeSource = new BehaviorSubject<boolean>(true);
  currentTimeZone$ = this.timeSource.asObservable();

  constructor() { }

  getNowUTC(): Observable<Date> {
    return timer(0, 1000)
    .pipe(
      map( () => new Date()),
      share()
    )
  }

  toggleTimeZone() {
    let timeZoneValue = this.timeSource.getValue();
    timeZoneValue = !timeZoneValue;
    this.setTimeZone(timeZoneValue);
  }

  getCurrentTimeZone(): boolean {
    return this.timeSource.getValue();
  }

  setTimeZone(isUtcTime: boolean) {
    const _message = new timeZoneMessage();
    _message.utcRecentTimeZone = isUtcTime;
    localStorage.setItem('user_data', JSON.stringify(_message));
    this.timeSource.next(_message.utcRecentTimeZone);  
  }

  getTimeZone() {
    const timeZoneState = localStorage.getItem('user_data');
    if(timeZoneState) {
      const _message: timeZoneMessage = JSON.parse(timeZoneState);
      //console.log(_message.utcRecentTimeZone);
      this.timeSource.next(_message.utcRecentTimeZone);
    }
  }
}
