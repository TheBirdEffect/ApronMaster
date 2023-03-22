import { Component } from '@angular/core';
import { order } from 'src/app/_models/order';
import { OrderService } from 'src/app/_service/order.service';

@Component({
  selector: 'app-table-orders-detail',
  templateUrl: './table-orders-detail.component.html',
  styleUrls: ['./table-orders-detail.component.scss']
})
export class TableOrdersDetailComponent {
  className: string;

  constructor(public orderService: OrderService) {}

  DeleteOrder(order: order) {
    this.orderService.DeleteOrder(order.orderId).subscribe();
  }

  toggleRowColor() {
    if(this.className === "active") {
      this.className = "";
    } else {
      this.className = "active";
    }

    console.log(this.className);
    
  }

}
