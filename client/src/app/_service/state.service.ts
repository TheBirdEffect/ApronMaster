import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { stateObservablesEnum } from '../_enums/stateObservablesEnum';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  //Orders
  orderDetailPreselectorSource = new BehaviorSubject<boolean>(false);
  orderDetailPreselectorIsOpen$ = this.orderDetailPreselectorSource.asObservable();

  orderCollectionTimeOffsetLoadingCompleteSource = new BehaviorSubject<boolean>(false);
  orderCollectionTimeOffsetLoadingComplete$ = this.orderCollectionTimeOffsetLoadingCompleteSource.asObservable()

  constructor() { }

  getStateObservable(stateEnum: stateObservablesEnum) {
    switch(stateEnum) {
      case stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN: {        
        return this.orderDetailPreselectorIsOpen$;
      }
      case stateObservablesEnum.ORDER_COLLECTION_TIME_OFFSET_LOADED: {
        return this.orderCollectionTimeOffsetLoadingComplete$;
      }
    }
  }

  setStateObservable(stateEnum: stateObservablesEnum, state: boolean) {
    switch(stateEnum) {
      case stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN: {      
        this.orderDetailPreselectorSource.next(state);
        break;
      }
      case stateObservablesEnum.ORDER_COLLECTION_TIME_OFFSET_LOADED: {
        this.orderCollectionTimeOffsetLoadingCompleteSource.next(state);
        
        break;
      }
    }
  }
}
