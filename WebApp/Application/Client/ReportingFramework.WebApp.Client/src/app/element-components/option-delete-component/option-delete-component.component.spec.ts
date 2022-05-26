import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptionDeleteComponentComponent } from './option-delete-component.component';

describe('OptionDeleteComponentComponent', () => {
  let component: OptionDeleteComponentComponent;
  let fixture: ComponentFixture<OptionDeleteComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OptionDeleteComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OptionDeleteComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
