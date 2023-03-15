import { Component, OnDestroy, OnInit } from '@angular/core';
import { OnSameUrlNavigation } from '@angular/router';
import { subscribeOn, Subscription, timestamp } from 'rxjs';
import { TimeService } from '../_service/time.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit, OnDestroy {
  rxTime = new Date();
  timeSubscription:Subscription;

  constructor(public timeService: TimeService) {}
  
  ngOnInit(): void {
    this.timeService.getNowUTC();
    this.timeSubscription = this.timeService.getNowUTC().subscribe(time => {
      this.rxTime = this.getTime(time);
    });    
    this.timeService.getTimeZone()
  }

  toggleUtcToLocal() {
    this.timeService.toggleTimeZone();
  }

  getTime(time: Date) {
    //Converting Local-Time to UTC-Time
    if(this.timeService.getCurrentTimeZone()){
      return new Date(time.getTime() + (time.getTimezoneOffset() * 60000));
    } else {
      return time;
    }
  }

  ngOnDestroy(): void {
    this.timeSubscription.unsubscribe();
  }
}
