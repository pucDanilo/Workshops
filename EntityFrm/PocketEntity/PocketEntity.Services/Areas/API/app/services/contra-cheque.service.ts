import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { ContraCheque } from './models/ContraCheque';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class ContraChequeService {

  private contraChequesUrl = 'api/contraCheques';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET contraCheques from the server */
  getContraCheques (): Observable<ContraCheque[]> {
    return this.http.get<ContraCheque[]>(this.contraChequesUrl)
      .pipe(
        tap(contraCheques => this.log('fetched contraCheques')),
        catchError(this.handleError('getContraCheques', []))
      );
  }

  /** GET contraCheque by id. Return `undefined` when id not found */
  getContraChequeNo404<Data>(id: number): Observable<ContraCheque> {
    const url = `${this.contraChequesUrl}/?id=${id}`;
    return this.http.get<ContraCheque[]>(url)
      .pipe(
        map(contraCheques => contraCheques[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} contraCheque id=${id}`);
        }),
        catchError(this.handleError<ContraCheque>(`getContraCheque id=${id}`))
      );
  }
  /** GET contraCheque by id. Will 404 if id not found */
  getContraCheque(id: number): Observable<ContraCheque> {
    const url = `${this.contraChequesUrl}/${id}`;
    return this.http.get<ContraCheque>(url).pipe(
      tap(_ => this.log(`fetched contraCheque id=${id}`)),
      catchError(this.handleError<ContraCheque>(`getContraCheque id=${id}`))
    );
  }

  /* GET contraCheques whose name contains search term */
  searchContraCheques(term: string): Observable<ContraCheque[]> {
    if (!term.trim()) {
      // if not search term, return empty contraCheque array.
      return of([]);
    }

    return this.http.get<ContraCheque[]>(`${this.contraChequesUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found contraCheques matching "${term}"`)),
      catchError(this.handleError<ContraCheque[]>('searchContraCheques', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new contraCheque to the server */
  addContraCheque (contraCheque: ContraCheque): Observable<ContraCheque> {
    return this.http.post<ContraCheque>(this.contraChequesUrl, contraCheque, httpOptions).pipe(
      tap((contraCheque: ContraCheque) => this.log(`added contraCheque w/ id=${contraCheque.id}`)),
      catchError(this.handleError<ContraCheque>('addContraCheque'))
    );
  }
  /** DELETE: delete the contraCheque from the server */
  deleteContraCheque (contraCheque: ContraCheque | number): Observable<ContraCheque> {
    const id = typeof contraCheque === 'number' ? contraCheque : contraCheque.id;
    const url = `${this.contraChequesUrl}/${id}`;
    return this.http.delete<ContraCheque>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted contraCheque id=${id}`)),
      catchError(this.handleError<ContraCheque>('deleteContraCheque'))
    );
  }
  /** PUT: update the contraCheque on the server */
  updateContraCheque (contraCheque: ContraCheque): Observable<any> {
    return this.http.put(this.contraChequesUrl, contraCheque, httpOptions).pipe(
      tap(_ => this.log(`updated contraCheque id=${contraCheque.id}`)),
      catchError(this.handleError<any>('updateContraCheque'))
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

  /** Log a ContraChequeService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`ContraChequeService: ${message}`);
  }
}
);
}