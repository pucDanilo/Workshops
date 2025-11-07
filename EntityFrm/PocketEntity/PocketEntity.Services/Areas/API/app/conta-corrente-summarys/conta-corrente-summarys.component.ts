
import { Component, OnInit } from '@angular/core';
import { ContaCorrenteSummary } from '../contaCorrenteSummary';
import { ContaCorrenteSummaryService } from '../contaCorrenteSummary.service';
@Component({
  selector: 'app-conta-corrente-summarys',
  templateUrl: './conta-corrente-summarys.component.html',
  styleUrls: ['./conta-corrente-summarys.component.css']
})
export class ContaCorrenteSummarysComponent implements OnInit {
  contaCorrenteSummarys: ContaCorrenteSummary[];

  constructor(private contaCorrenteSummaryService: ContaCorrenteSummaryService) { }

  ngOnInit() {
this.getContaCorrenteSummarys();
}

  getContaCorrenteSummarys(): void {
    this.contaCorrenteSummaryService.getContaCorrenteSummarys()
    .subscribe(contaCorrenteSummarys => this.contaCorrenteSummarys = contaCorrenteSummarys);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.contaCorrenteSummaryService.addContaCorrenteSummary({ name } as ContaCorrenteSummary)
      .subscribe(contaCorrenteSummary => {
        this.contaCorrenteSummarys.push(contaCorrenteSummary);
      });
  }
  delete(contaCorrenteSummary: ContaCorrenteSummary): void {
    this.contaCorrenteSummarys = this.contaCorrenteSummarys.filter(h => h !== contaCorrenteSummary);
    this.contaCorrenteSummaryService.deleteContaCorrenteSummary(contaCorrenteSummary).subscribe();
  }
}