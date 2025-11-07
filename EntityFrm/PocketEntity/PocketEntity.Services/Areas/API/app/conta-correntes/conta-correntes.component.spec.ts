
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ContaCorrentesComponent } from './contaCorrentes.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ContaCorrentesComponent', () => {
  let component: ContaCorrentesComponent;
  let fixture: ComponentFixture<ContaCorrentesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContaCorrentesComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContaCorrentesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});