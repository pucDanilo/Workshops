
import { Component, OnInit } from '@angular/core';
import { Transacao } from '../transacao';
import { TransacaoService } from '../transacao.service';
@Component({
  selector: 'app-transacaos',
  templateUrl: './transacaos.component.html',
  styleUrls: ['./transacaos.component.css']
})
export class TransacaosComponent implements OnInit {
  transacaos: Transacao[];

  constructor(private transacaoService: TransacaoService) { }

  ngOnInit() {
this.getTransacaos();
}

  getTransacaos(): void {
    this.transacaoService.getTransacaos()
    .subscribe(transacaos => this.transacaos = transacaos);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.transacaoService.addTransacao({ name } as Transacao)
      .subscribe(transacao => {
        this.transacaos.push(transacao);
      });
  }
  delete(transacao: Transacao): void {
    this.transacaos = this.transacaos.filter(h => h !== transacao);
    this.transacaoService.deleteTransacao(transacao).subscribe();
  }
}