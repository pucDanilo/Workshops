
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { NaturezasComponent } from './naturezas.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('NaturezasComponent', () => {
  let component: NaturezasComponent;
  let fixture: ComponentFixture<NaturezasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NaturezasComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NaturezasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});