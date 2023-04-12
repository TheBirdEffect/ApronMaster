import { Injectable, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  private modalSource = new BehaviorSubject<TemplateRef<any> | null>(null);
  currentModal = this.modalSource.asObservable();

  constructor(private modalService: BsModalService) { 
  }

  primaryModalRef?: BsModalRef;
  modalRefArray = new Array<BsModalRef>;

  configLarge = {
    backdrop: true,
    class: 'modal-lg'
  }

  openModal(template: TemplateRef<any>) {
    this.primaryModalRef = this.modalService.show(template, this.configLarge);
    this.modalRefArray.push(this.primaryModalRef);
    if(this.modalRefArray.length > 1) {
      this.modalRefArray.at(this.modalRefArray.length - 2)?.hide();
      this.modalRefArray.splice(0, this.modalRefArray.length-1);
    }
    console.log('Open Modal', this.modalRefArray);
  }

  closeModal() {
    // this.primaryModalRef?.hide();
    this.modalRefArray.forEach(modal => {
      modal.hide();
    })
    this.modalRefArray = [];
    console.log('Close Modal', this.modalRefArray);
    
  }

}
