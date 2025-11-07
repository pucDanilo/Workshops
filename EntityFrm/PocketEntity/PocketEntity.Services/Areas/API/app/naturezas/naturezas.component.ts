
import { Component, OnInit } from '@angular/core';
import { Natureza } from '../natureza';
import { NaturezaService } from '../natureza.service';
@Component({
  selector: 'app-naturezas',
  templateUrl: './naturezas.component.html',
  styleUrls: ['./naturezas.component.css']
})
export class NaturezasComponent implements OnInit {
  naturezas: Natureza[];

  constructor(private naturezaService: NaturezaService) { }

  ngOnInit() {
this.getNaturezas();
}

  getNaturezas(): void {
    this.naturezaService.getNaturezas()
    .subscribe(naturezas => this.naturezas = naturezas);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.naturezaService.addNatureza({ name } as Natureza)
      .subscribe(natureza => {
        this.naturezas.push(natureza);
      });
  }
  delete(natureza: Natureza): void {
    this.naturezas = this.naturezas.filter(h => h !== natureza);
    this.naturezaService.deleteNatureza(natureza).subscribe();
  }
}