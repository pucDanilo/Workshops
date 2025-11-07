
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { StockSummarysComponent } from './stockSummarys.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('StockSummarysComponent', () => {
  let component: StockSummarysComponent;
  let fixture: ComponentFixture<StockSummarysComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StockSummarysComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StockSummarysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});