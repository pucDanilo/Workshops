
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ContraChequeNaturezaSummarysComponent } from './contraChequeNaturezaSummarys.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ContraChequeNaturezaSummarysComponent', () => {
  let component: ContraChequeNaturezaSummarysComponent;
  let fixture: ComponentFixture<ContraChequeNaturezaSummarysComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContraChequeNaturezaSummarysComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContraChequeNaturezaSummarysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});