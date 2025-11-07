
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { TitulosComponent } from './titulos.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('TitulosComponent', () => {
  let component: TitulosComponent;
  let fixture: ComponentFixture<TitulosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TitulosComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TitulosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});