import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Titulo } from './models/Titulo';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class TituloService {

  private titulosUrl = 'api/titulos';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET titulos from the server */
  getTitulos (): Observable<Titulo[]> {
    return this.http.get<Titulo[]>(this.titulosUrl)
      .pipe(
        tap(titulos => this.log('fetched titulos')),
        catchError(this.handleError('getTitulos', []))
      );
  }

  /** GET titulo by id. Return `undefined` when id not found */
  getTituloNo404<Data>(id: number): Observable<Titulo> {
    const url = `${this.titulosUrl}/?id=${id}`;
    return this.http.get<Titulo[]>(url)
      .pipe(
        map(titulos => titulos[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} titulo id=${id}`);
        }),
        catchError(this.handleError<Titulo>(`getTitulo id=${id}`))
      );
  }
  /** GET titulo by id. Will 404 if id not found */
  getTitulo(id: number): Observable<Titulo> {
    const url = `${this.titulosUrl}/${id}`;
    return this.http.get<Titulo>(url).pipe(
      tap(_ => this.log(`fetched titulo id=${id}`)),
      catchError(this.handleError<Titulo>(`getTitulo id=${id}`))
    );
  }

  /* GET titulos whose name contains search term */
  searchTitulos(term: string): Observable<Titulo[]> {
    if (!term.trim()) {
      // if not search term, return empty titulo array.
      return of([]);
    }

    return this.http.get<Titulo[]>(`${this.titulosUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found titulos matching "${term}"`)),
      catchError(this.handleError<Titulo[]>('searchTitulos', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new titulo to the server */
  addTitulo (titulo: Titulo): Observable<Titulo> {
    return this.http.post<Titulo>(this.titulosUrl, titulo, httpOptions).pipe(
      tap((titulo: Titulo) => this.log(`added titulo w/ id=${titulo.id}`)),
      catchError(this.handleError<Titulo>('addTitulo'))
    );
  }
  /** DELETE: delete the titulo from the server */
  deleteTitulo (titulo: Titulo | number): Observable<Titulo> {
    const id = typeof titulo === 'number' ? titulo : titulo.id;
    const url = `${this.titulosUrl}/${id}`;
    return this.http.delete<Titulo>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted titulo id=${id}`)),
      catchError(this.handleError<Titulo>('deleteTitulo'))
    );
  }
  /** PUT: update the titulo on the server */
  updateTitulo (titulo: Titulo): Observable<any> {
    return this.http.put(this.titulosUrl, titulo, httpOptions).pipe(
      tap(_ => this.log(`updated titulo id=${titulo.id}`)),
      catchError(this.handleError<any>('updateTitulo'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
      // Let the app keep running by returning an empty result.
            return of(result as T);
    };
  }

  /** Log a TituloService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`TituloService: ${message}`);
  }
}
);
}