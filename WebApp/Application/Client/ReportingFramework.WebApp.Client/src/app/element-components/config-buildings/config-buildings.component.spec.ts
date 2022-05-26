import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfigBuildingsComponent } from './config-buildings.component';

describe('ConfigBuildingsComponent', () => {
  let component: ConfigBuildingsComponent;
  let fixture: ComponentFixture<ConfigBuildingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfigBuildingsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfigBuildingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
