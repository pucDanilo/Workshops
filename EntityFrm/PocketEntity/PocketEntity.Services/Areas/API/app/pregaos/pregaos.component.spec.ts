
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { PregaosComponent } from './pregaos.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('PregaosComponent', () => {
  let component: PregaosComponent;
  let fixture: ComponentFixture<PregaosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PregaosComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PregaosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});