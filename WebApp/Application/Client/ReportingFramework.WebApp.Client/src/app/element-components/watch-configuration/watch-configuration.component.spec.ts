import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WatchConfigurationComponent } from './watch-configuration.component';

describe('WatchConfigurationComponent', () => {
  let component: WatchConfigurationComponent;
  let fixture: ComponentFixture<WatchConfigurationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WatchConfigurationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WatchConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
