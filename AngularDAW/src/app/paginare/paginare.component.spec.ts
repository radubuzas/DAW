import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaginareComponent } from './paginare.component';

describe('PaginareComponent', () => {
  let component: PaginareComponent;
  let fixture: ComponentFixture<PaginareComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PaginareComponent]
    });
    fixture = TestBed.createComponent(PaginareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
