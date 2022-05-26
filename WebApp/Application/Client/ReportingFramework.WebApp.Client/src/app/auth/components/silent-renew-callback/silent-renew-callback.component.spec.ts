import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SilentRenewCallbackComponent } from './silent-renew-callback.component';

describe('SilentRenewCallbackComponent', () => {
  let component: SilentRenewCallbackComponent;
  let fixture: ComponentFixture<SilentRenewCallbackComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SilentRenewCallbackComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SilentRenewCallbackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
