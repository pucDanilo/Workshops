
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ContraChequesComponent } from './contraCheques.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ContraChequesComponent', () => {
  let component: ContraChequesComponent;
  let fixture: ComponentFixture<ContraChequesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContraChequesComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContraChequesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});