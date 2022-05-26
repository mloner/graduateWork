import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-option-delete-component',
  templateUrl: './option-delete-component.component.html',
  styleUrls: ['./option-delete-component.component.css']
})
export class OptionDeleteComponentComponent implements OnInit {

  @Input() public formModal: any;
  @Output() public param: any = new EventEmitter();

  constructor() { }

  // Modal Close
  closeModal(event:any) {
    event.preventDefault();
    event.stopPropagation();
    if(event.target.classList.contains("modal")) {
      this.formModal = false;
    }
  }

  accept(){
    this.param.emit(true);
    this.formModal = false;
  }

  cancel(){
    this.param.emit(false);
    this.formModal = false;
  }

  ngOnInit(): void {
  }

}
