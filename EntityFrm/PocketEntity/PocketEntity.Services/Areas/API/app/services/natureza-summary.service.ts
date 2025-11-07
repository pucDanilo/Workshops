import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { NaturezaSummary } from './models/NaturezaSummary';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class NaturezaSummaryService {

  private naturezaSummarysUrl = 'api/naturezaSummarys';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET naturezaSummarys from the server */
  getNaturezaSummarys (): Observable<NaturezaSummary[]> {
    return this.http.get<NaturezaSummary[]>(this.naturezaSummarysUrl)
      .pipe(
        tap(naturezaSummarys => this.log('fetched naturezaSummarys')),
        catchError(this.handleError('getNaturezaSummarys', []))
      );
  }

  /** GET naturezaSummary by id. Return `undefined` when id not found */
  getNaturezaSummaryNo404<Data>(id: number): Observable<NaturezaSummary> {
    const url = `${this.naturezaSummarysUrl}/?id=${id}`;
    return this.http.get<NaturezaSummary[]>(url)
      .pipe(
        map(naturezaSummarys => naturezaSummarys[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} naturezaSummary id=${id}`);
        }),
        catchError(this.handleError<NaturezaSummary>(`getNaturezaSummary id=${id}`))
      );
  }
  /** GET naturezaSummary by id. Will 404 if id not found */
  getNaturezaSummary(id: number): Observable<NaturezaSummary> {
    const url = `${this.naturezaSummarysUrl}/${id}`;
    return this.http.get<NaturezaSummary>(url).pipe(
      tap(_ => this.log(`fetched naturezaSummary id=${id}`)),
      catchError(this.handleError<NaturezaSummary>(`getNaturezaSummary id=${id}`))
    );
  }

  /* GET naturezaSummarys whose name contains search term */
  searchNaturezaSummarys(term: string): Observable<NaturezaSummary[]> {
    if (!term.trim()) {
      // if not search term, return empty naturezaSummary array.
      return of([]);
    }

    return this.http.get<NaturezaSummary[]>(`${this.naturezaSummarysUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found naturezaSummarys matching "${term}"`)),
      catchError(this.handleError<NaturezaSummary[]>('searchNaturezaSummarys', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new naturezaSummary to the server */
  addNaturezaSummary (naturezaSummary: NaturezaSummary): Observable<NaturezaSummary> {
    return this.http.post<NaturezaSummary>(this.naturezaSummarysUrl, naturezaSummary, httpOptions).pipe(
      tap((naturezaSummary: NaturezaSummary) => this.log(`added naturezaSummary w/ id=${naturezaSummary.id}`)),
      catchError(this.handleError<NaturezaSummary>('addNaturezaSummary'))
    );
  }
  /** DELETE: delete the naturezaSummary from the server */
  deleteNaturezaSummary (naturezaSummary: NaturezaSummary | number): Observable<NaturezaSummary> {
    const id = typeof naturezaSummary === 'number' ? naturezaSummary : naturezaSummary.id;
    const url = `${this.naturezaSummarysUrl}/${id}`;
    return this.http.delete<NaturezaSummary>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted naturezaSummary id=${id}`)),
      catchError(this.handleError<NaturezaSummary>('deleteNaturezaSummary'))
    );
  }
  /** PUT: update the naturezaSummary on the server */
  updateNaturezaSummary (naturezaSummary: NaturezaSummary): Observable<any> {
    return this.http.put(this.naturezaSummarysUrl, naturezaSummary, httpOptions).pipe(
      tap(_ => this.log(`updated naturezaSummary id=${naturezaSummary.id}`)),
      catchError(this.handleError<any>('updateNaturezaSummary'))
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

  /** Log a NaturezaSummaryService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`NaturezaSummaryService: ${message}`);
  }
}
);
}