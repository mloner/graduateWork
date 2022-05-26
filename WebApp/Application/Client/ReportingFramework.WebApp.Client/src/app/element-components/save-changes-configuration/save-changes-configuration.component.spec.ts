import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveChangesConfigurationComponent } from './save-changes-configuration.component';

describe('SaveChangesConfigurationComponent', () => {
  let component: SaveChangesConfigurationComponent;
  let fixture: ComponentFixture<SaveChangesConfigurationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SaveChangesConfigurationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SaveChangesConfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
