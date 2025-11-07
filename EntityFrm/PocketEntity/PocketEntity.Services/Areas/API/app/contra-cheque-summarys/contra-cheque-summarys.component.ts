
import { Component, OnInit } from '@angular/core';
import { ContraChequeSummary } from '../contraChequeSummary';
import { ContraChequeSummaryService } from '../contraChequeSummary.service';
@Component({
  selector: 'app-contra-cheque-summarys',
  templateUrl: './contra-cheque-summarys.component.html',
  styleUrls: ['./contra-cheque-summarys.component.css']
})
export class ContraChequeSummarysComponent implements OnInit {
  contraChequeSummarys: ContraChequeSummary[];

  constructor(private contraChequeSummaryService: ContraChequeSummaryService) { }

  ngOnInit() {
this.getContraChequeSummarys();
}

  getContraChequeSummarys(): void {
    this.contraChequeSummaryService.getContraChequeSummarys()
    .subscribe(contraChequeSummarys => this.contraChequeSummarys = contraChequeSummarys);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.contraChequeSummaryService.addContraChequeSummary({ name } as ContraChequeSummary)
      .subscribe(contraChequeSummary => {
        this.contraChequeSummarys.push(contraChequeSummary);
      });
  }
  delete(contraChequeSummary: ContraChequeSummary): void {
    this.contraChequeSummarys = this.contraChequeSummarys.filter(h => h !== contraChequeSummary);
    this.contraChequeSummaryService.deleteContraChequeSummary(contraChequeSummary).subscribe();
  }
}