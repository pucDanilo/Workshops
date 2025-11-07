
import { Component, OnInit } from '@angular/core';
import { Tenant } from '../tenant';
import { TenantService } from '../tenant.service';
@Component({
  selector: 'app-tenants',
  templateUrl: './tenants.component.html',
  styleUrls: ['./tenants.component.css']
})
export class TenantsComponent implements OnInit {
  tenants: Tenant[];

  constructor(private tenantService: TenantService) { }

  ngOnInit() {
this.getTenants();
}

  getTenants(): void {
    this.tenantService.getTenants()
    .subscribe(tenants => this.tenants = tenants);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.tenantService.addTenant({ name } as Tenant)
      .subscribe(tenant => {
        this.tenants.push(tenant);
      });
  }
  delete(tenant: Tenant): void {
    this.tenants = this.tenants.filter(h => h !== tenant);
    this.tenantService.deleteTenant(tenant).subscribe();
  }
}