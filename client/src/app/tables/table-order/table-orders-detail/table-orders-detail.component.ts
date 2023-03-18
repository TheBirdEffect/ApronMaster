import { Component } from '@angular/core';
import { OrderService } from 'src/app/_service/order.service';

@Component({
  selector: 'app-table-orders-detail',
  templateUrl: './table-orders-detail.component.html',
  styleUrls: ['./table-orders-detail.component.scss']
})
export class TableOrdersDetailComponent {

  constructor(private orderService: OrderService) {}

  GetFlightsOfOrders() {

  }
}
