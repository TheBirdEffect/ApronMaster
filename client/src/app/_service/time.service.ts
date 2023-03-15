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

  setTimeZone(isUtcTime: boolean) {
    const _message = new timeZoneMessage();
    _message.utcRecentTimeZone = isUtcTime;
    localStorage.setItem('data', JSON.stringify(_message));
    this.timeSource.next(_message.utcRecentTimeZone);  
  }

  getTimeZone() {
    const timeZoneState = localStorage.getItem('data');
    if(timeZoneState) {
      const _message: timeZoneMessage = JSON.parse(timeZoneState);
      this.timeSource.next(_message.utcRecentTimeZone);
    }
    
  }
}
