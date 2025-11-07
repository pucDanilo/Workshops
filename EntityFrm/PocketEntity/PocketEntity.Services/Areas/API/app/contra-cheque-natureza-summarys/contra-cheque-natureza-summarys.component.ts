
import { Component, OnInit } from '@angular/core';
import { ContraChequeNaturezaSummary } from '../contraChequeNaturezaSummary';
import { ContraChequeNaturezaSummaryService } from '../contraChequeNaturezaSummary.service';
@Component({
  selector: 'app-contra-cheque-natureza-summarys',
  templateUrl: './contra-cheque-natureza-summarys.component.html',
  styleUrls: ['./contra-cheque-natureza-summarys.component.css']
})
export class ContraChequeNaturezaSummarysComponent implements OnInit {
  contraChequeNaturezaSummarys: ContraChequeNaturezaSummary[];

  constructor(private contraChequeNaturezaSummaryService: ContraChequeNaturezaSummaryService) { }

  ngOnInit() {
this.getContraChequeNaturezaSummarys();
}

  getContraChequeNaturezaSummarys(): void {
    this.contraChequeNaturezaSummaryService.getContraChequeNaturezaSummarys()
    .subscribe(contraChequeNaturezaSummarys => this.contraChequeNaturezaSummarys = contraChequeNaturezaSummarys);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.contraChequeNaturezaSummaryService.addContraChequeNaturezaSummary({ name } as ContraChequeNaturezaSummary)
      .subscribe(contraChequeNaturezaSummary => {
        this.contraChequeNaturezaSummarys.push(contraChequeNaturezaSummary);
      });
  }
  delete(contraChequeNaturezaSummary: ContraChequeNaturezaSummary): void {
    this.contraChequeNaturezaSummarys = this.contraChequeNaturezaSummarys.filter(h => h !== contraChequeNaturezaSummary);
    this.contraChequeNaturezaSummaryService.deleteContraChequeNaturezaSummary(contraChequeNaturezaSummary).subscribe();
  }
}