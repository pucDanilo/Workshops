
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ContaCorrenteSummarysComponent } from './contaCorrenteSummarys.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ContaCorrenteSummarysComponent', () => {
  let component: ContaCorrenteSummarysComponent;
  let fixture: ComponentFixture<ContaCorrenteSummarysComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContaCorrenteSummarysComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContaCorrenteSummarysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});