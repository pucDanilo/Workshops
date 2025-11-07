import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { ContraChequeSummary } from './models/ContraChequeSummary';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class ContraChequeSummaryService {

  private contraChequeSummarysUrl = 'api/contraChequeSummarys';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET contraChequeSummarys from the server */
  getContraChequeSummarys (): Observable<ContraChequeSummary[]> {
    return this.http.get<ContraChequeSummary[]>(this.contraChequeSummarysUrl)
      .pipe(
        tap(contraChequeSummarys => this.log('fetched contraChequeSummarys')),
        catchError(this.handleError('getContraChequeSummarys', []))
      );
  }

  /** GET contraChequeSummary by id. Return `undefined` when id not found */
  getContraChequeSummaryNo404<Data>(id: number): Observable<ContraChequeSummary> {
    const url = `${this.contraChequeSummarysUrl}/?id=${id}`;
    return this.http.get<ContraChequeSummary[]>(url)
      .pipe(
        map(contraChequeSummarys => contraChequeSummarys[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} contraChequeSummary id=${id}`);
        }),
        catchError(this.handleError<ContraChequeSummary>(`getContraChequeSummary id=${id}`))
      );
  }
  /** GET contraChequeSummary by id. Will 404 if id not found */
  getContraChequeSummary(id: number): Observable<ContraChequeSummary> {
    const url = `${this.contraChequeSummarysUrl}/${id}`;
    return this.http.get<ContraChequeSummary>(url).pipe(
      tap(_ => this.log(`fetched contraChequeSummary id=${id}`)),
      catchError(this.handleError<ContraChequeSummary>(`getContraChequeSummary id=${id}`))
    );
  }

  /* GET contraChequeSummarys whose name contains search term */
  searchContraChequeSummarys(term: string): Observable<ContraChequeSummary[]> {
    if (!term.trim()) {
      // if not search term, return empty contraChequeSummary array.
      return of([]);
    }

    return this.http.get<ContraChequeSummary[]>(`${this.contraChequeSummarysUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found contraChequeSummarys matching "${term}"`)),
      catchError(this.handleError<ContraChequeSummary[]>('searchContraChequeSummarys', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new contraChequeSummary to the server */
  addContraChequeSummary (contraChequeSummary: ContraChequeSummary): Observable<ContraChequeSummary> {
    return this.http.post<ContraChequeSummary>(this.contraChequeSummarysUrl, contraChequeSummary, httpOptions).pipe(
      tap((contraChequeSummary: ContraChequeSummary) => this.log(`added contraChequeSummary w/ id=${contraChequeSummary.id}`)),
      catchError(this.handleError<ContraChequeSummary>('addContraChequeSummary'))
    );
  }
  /** DELETE: delete the contraChequeSummary from the server */
  deleteContraChequeSummary (contraChequeSummary: ContraChequeSummary | number): Observable<ContraChequeSummary> {
    const id = typeof contraChequeSummary === 'number' ? contraChequeSummary : contraChequeSummary.id;
    const url = `${this.contraChequeSummarysUrl}/${id}`;
    return this.http.delete<ContraChequeSummary>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted contraChequeSummary id=${id}`)),
      catchError(this.handleError<ContraChequeSummary>('deleteContraChequeSummary'))
    );
  }
  /** PUT: update the contraChequeSummary on the server */
  updateContraChequeSummary (contraChequeSummary: ContraChequeSummary): Observable<any> {
    return this.http.put(this.contraChequeSummarysUrl, contraChequeSummary, httpOptions).pipe(
      tap(_ => this.log(`updated contraChequeSummary id=${contraChequeSummary.id}`)),
      catchError(this.handleError<any>('updateContraChequeSummary'))
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

  /** Log a ContraChequeSummaryService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`ContraChequeSummaryService: ${message}`);
  }
}
);
}