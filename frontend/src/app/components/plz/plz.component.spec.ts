import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlzComponent } from './plz.component';

describe('PlzComponent', () => {
  let component: PlzComponent;
  let fixture: ComponentFixture<PlzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlzComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
