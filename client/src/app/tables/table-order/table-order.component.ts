import { Component, OnChanges, OnInit, SimpleChanges, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { stateObservablesEnum } from 'src/app/_enums/stateObservablesEnum';
import { order } from 'src/app/_models/order';
import { ModalService } from 'src/app/_service/modal.service';
import { OrderService } from 'src/app/_service/order.service';
import { StateService } from 'src/app/_service/state.service';

@Component({
  selector: 'app-table-order',
  templateUrl: './table-order.component.html',
  styleUrls: ['./table-order.component.scss'],
})
export class TableOrderComponent implements OnInit, OnChanges {
  ordersOfFlight$: Observable<order[] | null>;

  constructor(private modalService: BsModalService
    , private stateService: StateService
    , private customModalService: ModalService
    , public orderService: OrderService) {
  }


  modalIsOpened$: Observable<boolean>;
  modalIsOpen: boolean;
  preselectorModalRef?: BsModalRef;
  detailSelectModalRef?: BsModalRef;
  config = {
    backdrop: true,
    class: 'modal-lg'
  };



  ngOnInit(): void {
    this.stateService.getStateObservable(
      stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN
    ).subscribe(response => this.modalIsOpen = response);

    this.ordersOfFlight$ = this.orderService.loadOrdersOfFlight();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['modalIsOpen']) {
    }
  }

  openPreselectionModal(template: TemplateRef<any>) {
    this.customModalService.openModal(template);
  }

  // preselectRouter(
  //   isCollectionSelected: boolean,
  //   addOrderCollectionTemplate: TemplateRef<any>,
  //   addSingleOrderTemplate: TemplateRef<any>) {
  //   if (isCollectionSelected) {
  //     this.openModal(false, addOrderCollectionTemplate);
  //   } else {
  //     this.openModal(false, addSingleOrderTemplate);
  //   }
  // }

  // //modal
  // openModal(preselector: boolean, template: TemplateRef<any>) {
  //   //console.log('opened');
  //   if (preselector) {
  //     this.preselectorModalRef = this.modalService.show(template, this.config);
  //   } else {
  //     this.detailSelectModalRef = this.modalService.show(template, this.config);
  //   }

  // }

  // closeModal() {
  //   this.preselectorModalRef?.hide();
  //   this.detailSelectModalRef?.hide();
  // }

  // cancelFormMode(event: boolean) {
  //   this.stateService.setStateObservable(
  //     stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN
  //     , true
  //   )
  //   //this.closeModal()
  // }
}
