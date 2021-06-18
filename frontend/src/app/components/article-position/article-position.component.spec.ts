import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticlePositionComponent } from './article-position.component';

describe('ArticlePositionComponent', () => {
  let component: ArticlePositionComponent;
  let fixture: ComponentFixture<ArticlePositionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArticlePositionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticlePositionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
