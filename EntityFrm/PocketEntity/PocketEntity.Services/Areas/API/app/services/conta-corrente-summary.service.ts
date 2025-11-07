import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { ContaCorrenteSummary } from './models/ContaCorrenteSummary';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class ContaCorrenteSummaryService {

  private contaCorrenteSummarysUrl = 'api/contaCorrenteSummarys';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET contaCorrenteSummarys from the server */
  getContaCorrenteSummarys (): Observable<ContaCorrenteSummary[]> {
    return this.http.get<ContaCorrenteSummary[]>(this.contaCorrenteSummarysUrl)
      .pipe(
        tap(contaCorrenteSummarys => this.log('fetched contaCorrenteSummarys')),
        catchError(this.handleError('getContaCorrenteSummarys', []))
      );
  }

  /** GET contaCorrenteSummary by id. Return `undefined` when id not found */
  getContaCorrenteSummaryNo404<Data>(id: number): Observable<ContaCorrenteSummary> {
    const url = `${this.contaCorrenteSummarysUrl}/?id=${id}`;
    return this.http.get<ContaCorrenteSummary[]>(url)
      .pipe(
        map(contaCorrenteSummarys => contaCorrenteSummarys[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} contaCorrenteSummary id=${id}`);
        }),
        catchError(this.handleError<ContaCorrenteSummary>(`getContaCorrenteSummary id=${id}`))
      );
  }
  /** GET contaCorrenteSummary by id. Will 404 if id not found */
  getContaCorrenteSummary(id: number): Observable<ContaCorrenteSummary> {
    const url = `${this.contaCorrenteSummarysUrl}/${id}`;
    return this.http.get<ContaCorrenteSummary>(url).pipe(
      tap(_ => this.log(`fetched contaCorrenteSummary id=${id}`)),
      catchError(this.handleError<ContaCorrenteSummary>(`getContaCorrenteSummary id=${id}`))
    );
  }

  /* GET contaCorrenteSummarys whose name contains search term */
  searchContaCorrenteSummarys(term: string): Observable<ContaCorrenteSummary[]> {
    if (!term.trim()) {
      // if not search term, return empty contaCorrenteSummary array.
      return of([]);
    }

    return this.http.get<ContaCorrenteSummary[]>(`${this.contaCorrenteSummarysUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found contaCorrenteSummarys matching "${term}"`)),
      catchError(this.handleError<ContaCorrenteSummary[]>('searchContaCorrenteSummarys', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new contaCorrenteSummary to the server */
  addContaCorrenteSummary (contaCorrenteSummary: ContaCorrenteSummary): Observable<ContaCorrenteSummary> {
    return this.http.post<ContaCorrenteSummary>(this.contaCorrenteSummarysUrl, contaCorrenteSummary, httpOptions).pipe(
      tap((contaCorrenteSummary: ContaCorrenteSummary) => this.log(`added contaCorrenteSummary w/ id=${contaCorrenteSummary.id}`)),
      catchError(this.handleError<ContaCorrenteSummary>('addContaCorrenteSummary'))
    );
  }
  /** DELETE: delete the contaCorrenteSummary from the server */
  deleteContaCorrenteSummary (contaCorrenteSummary: ContaCorrenteSummary | number): Observable<ContaCorrenteSummary> {
    const id = typeof contaCorrenteSummary === 'number' ? contaCorrenteSummary : contaCorrenteSummary.id;
    const url = `${this.contaCorrenteSummarysUrl}/${id}`;
    return this.http.delete<ContaCorrenteSummary>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted contaCorrenteSummary id=${id}`)),
      catchError(this.handleError<ContaCorrenteSummary>('deleteContaCorrenteSummary'))
    );
  }
  /** PUT: update the contaCorrenteSummary on the server */
  updateContaCorrenteSummary (contaCorrenteSummary: ContaCorrenteSummary): Observable<any> {
    return this.http.put(this.contaCorrenteSummarysUrl, contaCorrenteSummary, httpOptions).pipe(
      tap(_ => this.log(`updated contaCorrenteSummary id=${contaCorrenteSummary.id}`)),
      catchError(this.handleError<any>('updateContaCorrenteSummary'))
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

  /** Log a ContaCorrenteSummaryService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`ContaCorrenteSummaryService: ${message}`);
  }
}
);
}