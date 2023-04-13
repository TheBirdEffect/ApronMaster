import { Component, EventEmitter, Output } from '@angular/core';
import { stateObservablesEnum } from 'src/app/_enums/stateObservablesEnum';
import { order } from 'src/app/_models/order';
import { OrderService } from 'src/app/_service/order.service';
import { StateService } from 'src/app/_service/state.service';

@Component({
  selector: 'app-table-orders-detail',
  templateUrl: './table-orders-detail.component.html',
  styleUrls: ['./table-orders-detail.component.scss']
})
export class TableOrdersDetailComponent {
  @Output() toggleModalState = new EventEmitter<boolean>();

  className: string;

  constructor(
    public orderService: OrderService,
    private stateService: StateService
    ) {}

  DeleteOrder(order: order) {
    this.orderService.DeleteOrder(order.orderId).subscribe();
  }

  toggleRowColor() {
    if(this.className === "active") {
      this.className = "";
    } else {
      this.className = "active";
    }

    //console.log(this.className);
    
  }

  openAddOrderPreselector() {
    this.toggleModalState.emit(true);
    this.stateService.setStateObservable(
      stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN
        ,true);
  }

}
