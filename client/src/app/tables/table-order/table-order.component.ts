import { Component, OnChanges, OnInit, SimpleChanges, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { stateObservablesEnum } from 'src/app/_enums/stateObservablesEnum';
import { StateService } from 'src/app/_service/state.service';

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
  preselectorModalRef?: BsModalRef;
  detailSelectModalRef?: BsModalRef;
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
    //this.closeModal();
    if(isCollectionSelected) {
      this.openModal(false, addOrderCollectionTemplate);
    } else {
      this.openModal(false, addSingleOrderTemplate);
    }
  }

  //modal
  openModal(preselector: boolean, template: TemplateRef<any>) {
    console.log('opened');
    if(preselector)
    {
      //this.closeModal(true);
      this.preselectorModalRef = this.modalService.show(template, this.config);
    } else {
      //this.closeModal(true);
      this.detailSelectModalRef = this.modalService.show(template, this.config);
    }
    
  }

  closeModal(preselector: boolean) {
    if(preselector)
    {
      this.preselectorModalRef?.hide();
    } else {
      this.detailSelectModalRef?.hide();
    }
  }

  cancelFormMode(event: boolean) {
    this.stateService.setStateObservable(
      stateObservablesEnum.ORDER_DETAIL_PRESELECTOR_IS_OPEN
      , true
    )
    //this.closeModal()
  }
}
