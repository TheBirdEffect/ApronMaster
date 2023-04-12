import { Component, EventEmitter, Output, TemplateRef } from '@angular/core';
import { ModalService } from 'src/app/_service/modal.service';

@Component({
  selector: 'app-preselector-order',
  templateUrl: './preselector-order.component.html',
  styleUrls: ['./preselector-order.component.scss']
})
export class PreselectorOrderComponent {
  @Output() collectionSelected = new EventEmitter();

  constructor(private modalService: ModalService) {}

  openTemplateOnModal(template: TemplateRef<any>) {
    this.modalService.openModal(template);
  }

  navigateToCollection(isCollectionSelected: boolean) {
    this.collectionSelected.emit(isCollectionSelected);    
  }
}
