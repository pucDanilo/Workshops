
import { Component, OnInit } from '@angular/core';
import { Titulo } from '../titulo';
import { TituloService } from '../titulo.service';
@Component({
  selector: 'app-titulos',
  templateUrl: './titulos.component.html',
  styleUrls: ['./titulos.component.css']
})
export class TitulosComponent implements OnInit {
  titulos: Titulo[];

  constructor(private tituloService: TituloService) { }

  ngOnInit() {
this.getTitulos();
}

  getTitulos(): void {
    this.tituloService.getTitulos()
    .subscribe(titulos => this.titulos = titulos);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.tituloService.addTitulo({ name } as Titulo)
      .subscribe(titulo => {
        this.titulos.push(titulo);
      });
  }
  delete(titulo: Titulo): void {
    this.titulos = this.titulos.filter(h => h !== titulo);
    this.tituloService.deleteTitulo(titulo).subscribe();
  }
}