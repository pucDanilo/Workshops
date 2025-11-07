
import { Component, OnInit } from '@angular/core';
import { Pregao } from '../pregao';
import { PregaoService } from '../pregao.service';
@Component({
  selector: 'app-pregaos',
  templateUrl: './pregaos.component.html',
  styleUrls: ['./pregaos.component.css']
})
export class PregaosComponent implements OnInit {
  pregaos: Pregao[];

  constructor(private pregaoService: PregaoService) { }

  ngOnInit() {
this.getPregaos();
}

  getPregaos(): void {
    this.pregaoService.getPregaos()
    .subscribe(pregaos => this.pregaos = pregaos);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.pregaoService.addPregao({ name } as Pregao)
      .subscribe(pregao => {
        this.pregaos.push(pregao);
      });
  }
  delete(pregao: Pregao): void {
    this.pregaos = this.pregaos.filter(h => h !== pregao);
    this.pregaoService.deletePregao(pregao).subscribe();
  }
}