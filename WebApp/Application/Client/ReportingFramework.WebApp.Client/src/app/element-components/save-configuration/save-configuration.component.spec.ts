import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveConfigurationComponent } from './save-configuration.component';

describe('SaveConfigurationComponent', () => {
  let component: SaveConfigurationComponent;
  let fixture: ComponentFixture<SaveConfigurationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SaveConfigurationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SaveConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
