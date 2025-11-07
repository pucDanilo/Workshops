import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Transacao } from './models/Transacao';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class TransacaoService {

  private transacaosUrl = 'api/transacaos';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET transacaos from the server */
  getTransacaos (): Observable<Transacao[]> {
    return this.http.get<Transacao[]>(this.transacaosUrl)
      .pipe(
        tap(transacaos => this.log('fetched transacaos')),
        catchError(this.handleError('getTransacaos', []))
      );
  }

  /** GET transacao by id. Return `undefined` when id not found */
  getTransacaoNo404<Data>(id: number): Observable<Transacao> {
    const url = `${this.transacaosUrl}/?id=${id}`;
    return this.http.get<Transacao[]>(url)
      .pipe(
        map(transacaos => transacaos[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} transacao id=${id}`);
        }),
        catchError(this.handleError<Transacao>(`getTransacao id=${id}`))
      );
  }
  /** GET transacao by id. Will 404 if id not found */
  getTransacao(id: number): Observable<Transacao> {
    const url = `${this.transacaosUrl}/${id}`;
    return this.http.get<Transacao>(url).pipe(
      tap(_ => this.log(`fetched transacao id=${id}`)),
      catchError(this.handleError<Transacao>(`getTransacao id=${id}`))
    );
  }

  /* GET transacaos whose name contains search term */
  searchTransacaos(term: string): Observable<Transacao[]> {
    if (!term.trim()) {
      // if not search term, return empty transacao array.
      return of([]);
    }

    return this.http.get<Transacao[]>(`${this.transacaosUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found transacaos matching "${term}"`)),
      catchError(this.handleError<Transacao[]>('searchTransacaos', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new transacao to the server */
  addTransacao (transacao: Transacao): Observable<Transacao> {
    return this.http.post<Transacao>(this.transacaosUrl, transacao, httpOptions).pipe(
      tap((transacao: Transacao) => this.log(`added transacao w/ id=${transacao.id}`)),
      catchError(this.handleError<Transacao>('addTransacao'))
    );
  }
  /** DELETE: delete the transacao from the server */
  deleteTransacao (transacao: Transacao | number): Observable<Transacao> {
    const id = typeof transacao === 'number' ? transacao : transacao.id;
    const url = `${this.transacaosUrl}/${id}`;
    return this.http.delete<Transacao>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted transacao id=${id}`)),
      catchError(this.handleError<Transacao>('deleteTransacao'))
    );
  }
  /** PUT: update the transacao on the server */
  updateTransacao (transacao: Transacao): Observable<any> {
    return this.http.put(this.transacaosUrl, transacao, httpOptions).pipe(
      tap(_ => this.log(`updated transacao id=${transacao.id}`)),
      catchError(this.handleError<any>('updateTransacao'))
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

  /** Log a TransacaoService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`TransacaoService: ${message}`);
  }
}
);
}