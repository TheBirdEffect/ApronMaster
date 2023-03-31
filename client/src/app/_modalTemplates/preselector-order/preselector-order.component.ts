import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-preselector-order',
  templateUrl: './preselector-order.component.html',
  styleUrls: ['./preselector-order.component.scss']
})
export class PreselectorOrderComponent {
  @Output() collectionSelected = new EventEmitter();

  onSubmit(isCollectionSelected: boolean) {
    this.collectionSelected.emit(isCollectionSelected);    
  }
}
