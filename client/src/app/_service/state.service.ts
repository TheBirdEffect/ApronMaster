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

  constructor() { }

  getStateObservable(stateEnum: stateObservablesEnum) {
    switch(stateEnum) {
      case stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN: {        
        return this.orderDetailPreselectorIsOpen$;
      }
    }
  }

  setStateObservable(stateEnum: stateObservablesEnum, state: boolean) {
    switch(stateEnum) {
      case stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN: {
        console.log('stateEnum: ', stateEnum); //Should equal 0
        console.log('State setted: ', state); // should equal true        
        this.orderDetailPreselectorSource.next(state);
      }
    }
  }
}
