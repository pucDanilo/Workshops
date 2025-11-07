
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ContraChequeSummarysComponent } from './contraChequeSummarys.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ContraChequeSummarysComponent', () => {
  let component: ContraChequeSummarysComponent;
  let fixture: ComponentFixture<ContraChequeSummarysComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContraChequeSummarysComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContraChequeSummarysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});