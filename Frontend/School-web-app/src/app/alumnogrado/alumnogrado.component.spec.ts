import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlumnogradoComponent } from './alumnogrado.component';

describe('AlumnogradoComponent', () => {
  let component: AlumnogradoComponent;
  let fixture: ComponentFixture<AlumnogradoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlumnogradoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlumnogradoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
