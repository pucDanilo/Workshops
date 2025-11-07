
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { NaturezaSummarysComponent } from './naturezaSummarys.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('NaturezaSummarysComponent', () => {
  let component: NaturezaSummarysComponent;
  let fixture: ComponentFixture<NaturezaSummarysComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NaturezaSummarysComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NaturezaSummarysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});