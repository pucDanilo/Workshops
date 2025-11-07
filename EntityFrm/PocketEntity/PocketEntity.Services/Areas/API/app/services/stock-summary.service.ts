import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { StockSummary } from './models/StockSummary';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class StockSummaryService {

  private stockSummarysUrl = 'api/stockSummarys';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET stockSummarys from the server */
  getStockSummarys (): Observable<StockSummary[]> {
    return this.http.get<StockSummary[]>(this.stockSummarysUrl)
      .pipe(
        tap(stockSummarys => this.log('fetched stockSummarys')),
        catchError(this.handleError('getStockSummarys', []))
      );
  }

  /** GET stockSummary by id. Return `undefined` when id not found */
  getStockSummaryNo404<Data>(id: number): Observable<StockSummary> {
    const url = `${this.stockSummarysUrl}/?id=${id}`;
    return this.http.get<StockSummary[]>(url)
      .pipe(
        map(stockSummarys => stockSummarys[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} stockSummary id=${id}`);
        }),
        catchError(this.handleError<StockSummary>(`getStockSummary id=${id}`))
      );
  }
  /** GET stockSummary by id. Will 404 if id not found */
  getStockSummary(id: number): Observable<StockSummary> {
    const url = `${this.stockSummarysUrl}/${id}`;
    return this.http.get<StockSummary>(url).pipe(
      tap(_ => this.log(`fetched stockSummary id=${id}`)),
      catchError(this.handleError<StockSummary>(`getStockSummary id=${id}`))
    );
  }

  /* GET stockSummarys whose name contains search term */
  searchStockSummarys(term: string): Observable<StockSummary[]> {
    if (!term.trim()) {
      // if not search term, return empty stockSummary array.
      return of([]);
    }

    return this.http.get<StockSummary[]>(`${this.stockSummarysUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found stockSummarys matching "${term}"`)),
      catchError(this.handleError<StockSummary[]>('searchStockSummarys', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new stockSummary to the server */
  addStockSummary (stockSummary: StockSummary): Observable<StockSummary> {
    return this.http.post<StockSummary>(this.stockSummarysUrl, stockSummary, httpOptions).pipe(
      tap((stockSummary: StockSummary) => this.log(`added stockSummary w/ id=${stockSummary.id}`)),
      catchError(this.handleError<StockSummary>('addStockSummary'))
    );
  }
  /** DELETE: delete the stockSummary from the server */
  deleteStockSummary (stockSummary: StockSummary | number): Observable<StockSummary> {
    const id = typeof stockSummary === 'number' ? stockSummary : stockSummary.id;
    const url = `${this.stockSummarysUrl}/${id}`;
    return this.http.delete<StockSummary>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted stockSummary id=${id}`)),
      catchError(this.handleError<StockSummary>('deleteStockSummary'))
    );
  }
  /** PUT: update the stockSummary on the server */
  updateStockSummary (stockSummary: StockSummary): Observable<any> {
    return this.http.put(this.stockSummarysUrl, stockSummary, httpOptions).pipe(
      tap(_ => this.log(`updated stockSummary id=${stockSummary.id}`)),
      catchError(this.handleError<any>('updateStockSummary'))
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

  /** Log a StockSummaryService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`StockSummaryService: ${message}`);
  }
}
);
}