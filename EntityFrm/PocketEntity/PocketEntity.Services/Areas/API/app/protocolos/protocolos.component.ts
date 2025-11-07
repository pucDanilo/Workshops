
import { Component, OnInit } from '@angular/core';
import { Protocolo } from '../protocolo';
import { ProtocoloService } from '../protocolo.service';
@Component({
  selector: 'app-protocolos',
  templateUrl: './protocolos.component.html',
  styleUrls: ['./protocolos.component.css']
})
export class ProtocolosComponent implements OnInit {
  protocolos: Protocolo[];

  constructor(private protocoloService: ProtocoloService) { }

  ngOnInit() {
this.getProtocolos();
}

  getProtocolos(): void {
    this.protocoloService.getProtocolos()
    .subscribe(protocolos => this.protocolos = protocolos);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.protocoloService.addProtocolo({ name } as Protocolo)
      .subscribe(protocolo => {
        this.protocolos.push(protocolo);
      });
  }
  delete(protocolo: Protocolo): void {
    this.protocolos = this.protocolos.filter(h => h !== protocolo);
    this.protocoloService.deleteProtocolo(protocolo).subscribe();
  }
}