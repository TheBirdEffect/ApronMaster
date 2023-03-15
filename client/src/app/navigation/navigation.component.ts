import { Component, OnInit } from '@angular/core';
import { Subscription, timestamp } from 'rxjs';
import { TimeService } from '../_service/time.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {
  rxTime = new Date();
  timeSubscription:Subscription;
  isUtcTime = true;

  constructor(public timeService: TimeService) {}
  
  ngOnInit(): void {
    this.timeService.getNowUTC();
    this.timeSubscription = this.timeService.getNowUTC().subscribe(time => {
      this.rxTime = this.getTime(time);
    });    
    this.timeService.getTimeZone();
  }

  toggleUtcToLocal() {
    this.isUtcTime = !this.isUtcTime; 
    this.timeService.setTimeZone(this.isUtcTime);
  }

  getTime(time: Date) {
    //Converting Local-Time to UTC-Time
    if(this.isUtcTime){
      return new Date(time.getTime() + (time.getTimezoneOffset() * 60000));
    } else {
      return time;
    }
    
  }
}
