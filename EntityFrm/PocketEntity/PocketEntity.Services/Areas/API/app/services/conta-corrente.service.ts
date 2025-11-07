import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { ContaCorrente } from './models/ContaCorrente';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class ContaCorrenteService {

  private contaCorrentesUrl = 'api/contaCorrentes';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET contaCorrentes from the server */
  getContaCorrentes (): Observable<ContaCorrente[]> {
    return this.http.get<ContaCorrente[]>(this.contaCorrentesUrl)
      .pipe(
        tap(contaCorrentes => this.log('fetched contaCorrentes')),
        catchError(this.handleError('getContaCorrentes', []))
      );
  }

  /** GET contaCorrente by id. Return `undefined` when id not found */
  getContaCorrenteNo404<Data>(id: number): Observable<ContaCorrente> {
    const url = `${this.contaCorrentesUrl}/?id=${id}`;
    return this.http.get<ContaCorrente[]>(url)
      .pipe(
        map(contaCorrentes => contaCorrentes[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} contaCorrente id=${id}`);
        }),
        catchError(this.handleError<ContaCorrente>(`getContaCorrente id=${id}`))
      );
  }
  /** GET contaCorrente by id. Will 404 if id not found */
  getContaCorrente(id: number): Observable<ContaCorrente> {
    const url = `${this.contaCorrentesUrl}/${id}`;
    return this.http.get<ContaCorrente>(url).pipe(
      tap(_ => this.log(`fetched contaCorrente id=${id}`)),
      catchError(this.handleError<ContaCorrente>(`getContaCorrente id=${id}`))
    );
  }

  /* GET contaCorrentes whose name contains search term */
  searchContaCorrentes(term: string): Observable<ContaCorrente[]> {
    if (!term.trim()) {
      // if not search term, return empty contaCorrente array.
      return of([]);
    }

    return this.http.get<ContaCorrente[]>(`${this.contaCorrentesUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found contaCorrentes matching "${term}"`)),
      catchError(this.handleError<ContaCorrente[]>('searchContaCorrentes', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new contaCorrente to the server */
  addContaCorrente (contaCorrente: ContaCorrente): Observable<ContaCorrente> {
    return this.http.post<ContaCorrente>(this.contaCorrentesUrl, contaCorrente, httpOptions).pipe(
      tap((contaCorrente: ContaCorrente) => this.log(`added contaCorrente w/ id=${contaCorrente.id}`)),
      catchError(this.handleError<ContaCorrente>('addContaCorrente'))
    );
  }
  /** DELETE: delete the contaCorrente from the server */
  deleteContaCorrente (contaCorrente: ContaCorrente | number): Observable<ContaCorrente> {
    const id = typeof contaCorrente === 'number' ? contaCorrente : contaCorrente.id;
    const url = `${this.contaCorrentesUrl}/${id}`;
    return this.http.delete<ContaCorrente>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted contaCorrente id=${id}`)),
      catchError(this.handleError<ContaCorrente>('deleteContaCorrente'))
    );
  }
  /** PUT: update the contaCorrente on the server */
  updateContaCorrente (contaCorrente: ContaCorrente): Observable<any> {
    return this.http.put(this.contaCorrentesUrl, contaCorrente, httpOptions).pipe(
      tap(_ => this.log(`updated contaCorrente id=${contaCorrente.id}`)),
      catchError(this.handleError<any>('updateContaCorrente'))
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

  /** Log a ContaCorrenteService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`ContaCorrenteService: ${message}`);
  }
}
);
}