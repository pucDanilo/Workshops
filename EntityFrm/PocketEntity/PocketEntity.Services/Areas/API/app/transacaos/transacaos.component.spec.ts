
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { TransacaosComponent } from './transacaos.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('TransacaosComponent', () => {
  let component: TransacaosComponent;
  let fixture: ComponentFixture<TransacaosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TransacaosComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TransacaosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});