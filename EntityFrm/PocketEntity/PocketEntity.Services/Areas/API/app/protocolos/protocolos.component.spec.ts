
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ProtocolosComponent } from './protocolos.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ProtocolosComponent', () => {
  let component: ProtocolosComponent;
  let fixture: ComponentFixture<ProtocolosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProtocolosComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProtocolosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});