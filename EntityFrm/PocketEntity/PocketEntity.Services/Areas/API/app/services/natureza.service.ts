import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Natureza } from './models/Natureza';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class NaturezaService {

  private naturezasUrl = 'api/naturezas';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET naturezas from the server */
  getNaturezas (): Observable<Natureza[]> {
    return this.http.get<Natureza[]>(this.naturezasUrl)
      .pipe(
        tap(naturezas => this.log('fetched naturezas')),
        catchError(this.handleError('getNaturezas', []))
      );
  }

  /** GET natureza by id. Return `undefined` when id not found */
  getNaturezaNo404<Data>(id: number): Observable<Natureza> {
    const url = `${this.naturezasUrl}/?id=${id}`;
    return this.http.get<Natureza[]>(url)
      .pipe(
        map(naturezas => naturezas[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} natureza id=${id}`);
        }),
        catchError(this.handleError<Natureza>(`getNatureza id=${id}`))
      );
  }
  /** GET natureza by id. Will 404 if id not found */
  getNatureza(id: number): Observable<Natureza> {
    const url = `${this.naturezasUrl}/${id}`;
    return this.http.get<Natureza>(url).pipe(
      tap(_ => this.log(`fetched natureza id=${id}`)),
      catchError(this.handleError<Natureza>(`getNatureza id=${id}`))
    );
  }

  /* GET naturezas whose name contains search term */
  searchNaturezas(term: string): Observable<Natureza[]> {
    if (!term.trim()) {
      // if not search term, return empty natureza array.
      return of([]);
    }

    return this.http.get<Natureza[]>(`${this.naturezasUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found naturezas matching "${term}"`)),
      catchError(this.handleError<Natureza[]>('searchNaturezas', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new natureza to the server */
  addNatureza (natureza: Natureza): Observable<Natureza> {
    return this.http.post<Natureza>(this.naturezasUrl, natureza, httpOptions).pipe(
      tap((natureza: Natureza) => this.log(`added natureza w/ id=${natureza.id}`)),
      catchError(this.handleError<Natureza>('addNatureza'))
    );
  }
  /** DELETE: delete the natureza from the server */
  deleteNatureza (natureza: Natureza | number): Observable<Natureza> {
    const id = typeof natureza === 'number' ? natureza : natureza.id;
    const url = `${this.naturezasUrl}/${id}`;
    return this.http.delete<Natureza>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted natureza id=${id}`)),
      catchError(this.handleError<Natureza>('deleteNatureza'))
    );
  }
  /** PUT: update the natureza on the server */
  updateNatureza (natureza: Natureza): Observable<any> {
    return this.http.put(this.naturezasUrl, natureza, httpOptions).pipe(
      tap(_ => this.log(`updated natureza id=${natureza.id}`)),
      catchError(this.handleError<any>('updateNatureza'))
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

  /** Log a NaturezaService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`NaturezaService: ${message}`);
  }
}
);
}