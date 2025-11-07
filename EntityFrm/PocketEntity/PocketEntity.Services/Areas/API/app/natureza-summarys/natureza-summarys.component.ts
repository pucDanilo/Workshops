
import { Component, OnInit } from '@angular/core';
import { NaturezaSummary } from '../naturezaSummary';
import { NaturezaSummaryService } from '../naturezaSummary.service';
@Component({
  selector: 'app-natureza-summarys',
  templateUrl: './natureza-summarys.component.html',
  styleUrls: ['./natureza-summarys.component.css']
})
export class NaturezaSummarysComponent implements OnInit {
  naturezaSummarys: NaturezaSummary[];

  constructor(private naturezaSummaryService: NaturezaSummaryService) { }

  ngOnInit() {
this.getNaturezaSummarys();
}

  getNaturezaSummarys(): void {
    this.naturezaSummaryService.getNaturezaSummarys()
    .subscribe(naturezaSummarys => this.naturezaSummarys = naturezaSummarys);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.naturezaSummaryService.addNaturezaSummary({ name } as NaturezaSummary)
      .subscribe(naturezaSummary => {
        this.naturezaSummarys.push(naturezaSummary);
      });
  }
  delete(naturezaSummary: NaturezaSummary): void {
    this.naturezaSummarys = this.naturezaSummarys.filter(h => h !== naturezaSummary);
    this.naturezaSummaryService.deleteNaturezaSummary(naturezaSummary).subscribe();
  }
}