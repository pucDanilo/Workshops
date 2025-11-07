
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { TenantsComponent } from './tenants.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('TenantsComponent', () => {
  let component: TenantsComponent;
  let fixture: ComponentFixture<TenantsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TenantsComponent ],
      imports: [RouterTestingModule.withRoutes([]), HttpClientTestingModule],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TenantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});