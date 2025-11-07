
import { Component, OnInit } from '@angular/core';
import { ContaCorrente } from '../contaCorrente';
import { ContaCorrenteService } from '../contaCorrente.service';
@Component({
  selector: 'app-conta-correntes',
  templateUrl: './conta-correntes.component.html',
  styleUrls: ['./conta-correntes.component.css']
})
export class ContaCorrentesComponent implements OnInit {
  contaCorrentes: ContaCorrente[];

  constructor(private contaCorrenteService: ContaCorrenteService) { }

  ngOnInit() {
this.getContaCorrentes();
}

  getContaCorrentes(): void {
    this.contaCorrenteService.getContaCorrentes()
    .subscribe(contaCorrentes => this.contaCorrentes = contaCorrentes);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.contaCorrenteService.addContaCorrente({ name } as ContaCorrente)
      .subscribe(contaCorrente => {
        this.contaCorrentes.push(contaCorrente);
      });
  }
  delete(contaCorrente: ContaCorrente): void {
    this.contaCorrentes = this.contaCorrentes.filter(h => h !== contaCorrente);
    this.contaCorrenteService.deleteContaCorrente(contaCorrente).subscribe();
  }
}