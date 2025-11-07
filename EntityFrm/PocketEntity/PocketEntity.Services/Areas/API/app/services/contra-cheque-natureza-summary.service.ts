import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { ContraChequeNaturezaSummary } from './models/ContraChequeNaturezaSummary';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class ContraChequeNaturezaSummaryService {

  private contraChequeNaturezaSummarysUrl = 'api/contraChequeNaturezaSummarys';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET contraChequeNaturezaSummarys from the server */
  getContraChequeNaturezaSummarys (): Observable<ContraChequeNaturezaSummary[]> {
    return this.http.get<ContraChequeNaturezaSummary[]>(this.contraChequeNaturezaSummarysUrl)
      .pipe(
        tap(contraChequeNaturezaSummarys => this.log('fetched contraChequeNaturezaSummarys')),
        catchError(this.handleError('getContraChequeNaturezaSummarys', []))
      );
  }

  /** GET contraChequeNaturezaSummary by id. Return `undefined` when id not found */
  getContraChequeNaturezaSummaryNo404<Data>(id: number): Observable<ContraChequeNaturezaSummary> {
    const url = `${this.contraChequeNaturezaSummarysUrl}/?id=${id}`;
    return this.http.get<ContraChequeNaturezaSummary[]>(url)
      .pipe(
        map(contraChequeNaturezaSummarys => contraChequeNaturezaSummarys[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} contraChequeNaturezaSummary id=${id}`);
        }),
        catchError(this.handleError<ContraChequeNaturezaSummary>(`getContraChequeNaturezaSummary id=${id}`))
      );
  }
  /** GET contraChequeNaturezaSummary by id. Will 404 if id not found */
  getContraChequeNaturezaSummary(id: number): Observable<ContraChequeNaturezaSummary> {
    const url = `${this.contraChequeNaturezaSummarysUrl}/${id}`;
    return this.http.get<ContraChequeNaturezaSummary>(url).pipe(
      tap(_ => this.log(`fetched contraChequeNaturezaSummary id=${id}`)),
      catchError(this.handleError<ContraChequeNaturezaSummary>(`getContraChequeNaturezaSummary id=${id}`))
    );
  }

  /* GET contraChequeNaturezaSummarys whose name contains search term */
  searchContraChequeNaturezaSummarys(term: string): Observable<ContraChequeNaturezaSummary[]> {
    if (!term.trim()) {
      // if not search term, return empty contraChequeNaturezaSummary array.
      return of([]);
    }

    return this.http.get<ContraChequeNaturezaSummary[]>(`${this.contraChequeNaturezaSummarysUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found contraChequeNaturezaSummarys matching "${term}"`)),
      catchError(this.handleError<ContraChequeNaturezaSummary[]>('searchContraChequeNaturezaSummarys', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new contraChequeNaturezaSummary to the server */
  addContraChequeNaturezaSummary (contraChequeNaturezaSummary: ContraChequeNaturezaSummary): Observable<ContraChequeNaturezaSummary> {
    return this.http.post<ContraChequeNaturezaSummary>(this.contraChequeNaturezaSummarysUrl, contraChequeNaturezaSummary, httpOptions).pipe(
      tap((contraChequeNaturezaSummary: ContraChequeNaturezaSummary) => this.log(`added contraChequeNaturezaSummary w/ id=${contraChequeNaturezaSummary.id}`)),
      catchError(this.handleError<ContraChequeNaturezaSummary>('addContraChequeNaturezaSummary'))
    );
  }
  /** DELETE: delete the contraChequeNaturezaSummary from the server */
  deleteContraChequeNaturezaSummary (contraChequeNaturezaSummary: ContraChequeNaturezaSummary | number): Observable<ContraChequeNaturezaSummary> {
    const id = typeof contraChequeNaturezaSummary === 'number' ? contraChequeNaturezaSummary : contraChequeNaturezaSummary.id;
    const url = `${this.contraChequeNaturezaSummarysUrl}/${id}`;
    return this.http.delete<ContraChequeNaturezaSummary>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted contraChequeNaturezaSummary id=${id}`)),
      catchError(this.handleError<ContraChequeNaturezaSummary>('deleteContraChequeNaturezaSummary'))
    );
  }
  /** PUT: update the contraChequeNaturezaSummary on the server */
  updateContraChequeNaturezaSummary (contraChequeNaturezaSummary: ContraChequeNaturezaSummary): Observable<any> {
    return this.http.put(this.contraChequeNaturezaSummarysUrl, contraChequeNaturezaSummary, httpOptions).pipe(
      tap(_ => this.log(`updated contraChequeNaturezaSummary id=${contraChequeNaturezaSummary.id}`)),
      catchError(this.handleError<any>('updateContraChequeNaturezaSummary'))
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

  /** Log a ContraChequeNaturezaSummaryService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`ContraChequeNaturezaSummaryService: ${message}`);
  }
}
);
}