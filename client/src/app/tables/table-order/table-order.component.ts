import { Component, Input, OnChanges, OnInit, SimpleChanges, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { stateObservablesEnum } from 'src/app/_enums/stateObservablesEnum';
import { FlightsService } from 'src/app/_service/flights.service';
import { OrderService } from 'src/app/_service/order.service';
import { PositionService } from 'src/app/_service/position.service';
import { StateService } from 'src/app/_service/state.service';
import { VehicleService } from 'src/app/_service/vehicle.service';

@Component({
  selector: 'app-table-order',
  templateUrl: './table-order.component.html',
  styleUrls: ['./table-order.component.scss'],
})
export class TableOrderComponent implements OnInit, OnChanges {

  constructor(private modalService: BsModalService
    , private stateService: StateService) {
  }
  

  modalIsOpened$: Observable<boolean>;
  modalIsOpen: boolean;
  modalRef?: BsModalRef;
  config = {
    backdrop: true,
    class: 'modal-lg'
  };



  ngOnInit(): void {
    this.stateService.getStateObservable(
      stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN
    ).subscribe( response => this.modalIsOpen = response);    
  }

  ngOnChanges(changes: SimpleChanges): void {
    if(changes['modalIsOpen']) {
    }
  }

  preselectRouter(
    isCollectionSelected: boolean,
    addOrderCollectionTemplate: TemplateRef<any>,
    addSingleOrderTemplate: TemplateRef<any>) 
    {
    this.closeModal();
    if(isCollectionSelected) {
      this.openModal(addOrderCollectionTemplate);
    } else {
      this.openModal(addSingleOrderTemplate);
    }
  }

  //modal
  openModal(template: TemplateRef<any>) {
    console.log('opened');
    this.modalRef = this.modalService.show(template, this.config);
  }

  closeModal() {
    this.modalRef?.hide();
  }

  cancelFormMode(event: boolean) {
    this.stateService.setStateObservable(
      stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN
      , true
    )
    this.closeModal()
  }
}
