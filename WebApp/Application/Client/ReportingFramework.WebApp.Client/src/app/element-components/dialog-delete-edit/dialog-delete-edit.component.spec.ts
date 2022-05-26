import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogDeleteEditComponent } from './dialog-delete-edit.component';

describe('DialogDeleteEditComponent', () => {
  let component: DialogDeleteEditComponent;
  let fixture: ComponentFixture<DialogDeleteEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogDeleteEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogDeleteEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
