import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FlightsService } from 'src/app/_service/flights.service';
import { OrderService } from 'src/app/_service/order.service';
import { PositionService } from 'src/app/_service/position.service';
import { VehicleService } from 'src/app/_service/vehicle.service';

@Component({
  selector: 'app-table-order',
  templateUrl: './table-order.component.html',
  styleUrls: ['./table-order.component.scss'],
})
export class TableOrderComponent implements OnInit {

  constructor(private modalService: BsModalService) { 
    }

    modalIsOpened = false;
    modalRef?: BsModalRef;

  ngOnInit(): void {     
  }


    //modal
    openModal(template: TemplateRef<any>) {
      this.modalRef = this.modalService.show(template);
    }
  
    closeModal() {
      this.modalRef?.hide();
    }
  
    toggleModalMode() {
      this.modalIsOpened = !this.modalIsOpened;
    }
  
    cancelFormMode(event: boolean) {
      this.modalIsOpened = event;
      this.closeModal()
    }
}
