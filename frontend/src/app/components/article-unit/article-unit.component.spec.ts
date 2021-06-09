import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleUnitComponent } from './article-unit.component';

describe('ArticleUnitComponent', () => {
  let component: ArticleUnitComponent;
  let fixture: ComponentFixture<ArticleUnitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArticleUnitComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticleUnitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
