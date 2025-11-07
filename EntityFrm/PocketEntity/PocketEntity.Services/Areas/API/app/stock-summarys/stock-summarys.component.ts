
import { Component, OnInit } from '@angular/core';
import { StockSummary } from '../stockSummary';
import { StockSummaryService } from '../stockSummary.service';
@Component({
  selector: 'app-stock-summarys',
  templateUrl: './stock-summarys.component.html',
  styleUrls: ['./stock-summarys.component.css']
})
export class StockSummarysComponent implements OnInit {
  stockSummarys: StockSummary[];

  constructor(private stockSummaryService: StockSummaryService) { }

  ngOnInit() {
this.getStockSummarys();
}

  getStockSummarys(): void {
    this.stockSummaryService.getStockSummarys()
    .subscribe(stockSummarys => this.stockSummarys = stockSummarys);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.stockSummaryService.addStockSummary({ name } as StockSummary)
      .subscribe(stockSummary => {
        this.stockSummarys.push(stockSummary);
      });
  }
  delete(stockSummary: StockSummary): void {
    this.stockSummarys = this.stockSummarys.filter(h => h !== stockSummary);
    this.stockSummaryService.deleteStockSummary(stockSummary).subscribe();
  }
}