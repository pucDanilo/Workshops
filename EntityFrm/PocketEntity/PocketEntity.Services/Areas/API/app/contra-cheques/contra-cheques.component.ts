
import { Component, OnInit } from '@angular/core';
import { ContraCheque } from '../contraCheque';
import { ContraChequeService } from '../contraCheque.service';
@Component({
  selector: 'app-contra-cheques',
  templateUrl: './contra-cheques.component.html',
  styleUrls: ['./contra-cheques.component.css']
})
export class ContraChequesComponent implements OnInit {
  contraCheques: ContraCheque[];

  constructor(private contraChequeService: ContraChequeService) { }

  ngOnInit() {
this.getContraCheques();
}

  getContraCheques(): void {
    this.contraChequeService.getContraCheques()
    .subscribe(contraCheques => this.contraCheques = contraCheques);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.contraChequeService.addContraCheque({ name } as ContraCheque)
      .subscribe(contraCheque => {
        this.contraCheques.push(contraCheque);
      });
  }
  delete(contraCheque: ContraCheque): void {
    this.contraCheques = this.contraCheques.filter(h => h !== contraCheque);
    this.contraChequeService.deleteContraCheque(contraCheque).subscribe();
  }
}