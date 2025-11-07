import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Protocolo } from './models/Protocolo';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class ProtocoloService {

  private protocolosUrl = 'api/protocolos';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET protocolos from the server */
  getProtocolos (): Observable<Protocolo[]> {
    return this.http.get<Protocolo[]>(this.protocolosUrl)
      .pipe(
        tap(protocolos => this.log('fetched protocolos')),
        catchError(this.handleError('getProtocolos', []))
      );
  }

  /** GET protocolo by id. Return `undefined` when id not found */
  getProtocoloNo404<Data>(id: number): Observable<Protocolo> {
    const url = `${this.protocolosUrl}/?id=${id}`;
    return this.http.get<Protocolo[]>(url)
      .pipe(
        map(protocolos => protocolos[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} protocolo id=${id}`);
        }),
        catchError(this.handleError<Protocolo>(`getProtocolo id=${id}`))
      );
  }
  /** GET protocolo by id. Will 404 if id not found */
  getProtocolo(id: number): Observable<Protocolo> {
    const url = `${this.protocolosUrl}/${id}`;
    return this.http.get<Protocolo>(url).pipe(
      tap(_ => this.log(`fetched protocolo id=${id}`)),
      catchError(this.handleError<Protocolo>(`getProtocolo id=${id}`))
    );
  }

  /* GET protocolos whose name contains search term */
  searchProtocolos(term: string): Observable<Protocolo[]> {
    if (!term.trim()) {
      // if not search term, return empty protocolo array.
      return of([]);
    }

    return this.http.get<Protocolo[]>(`${this.protocolosUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found protocolos matching "${term}"`)),
      catchError(this.handleError<Protocolo[]>('searchProtocolos', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new protocolo to the server */
  addProtocolo (protocolo: Protocolo): Observable<Protocolo> {
    return this.http.post<Protocolo>(this.protocolosUrl, protocolo, httpOptions).pipe(
      tap((protocolo: Protocolo) => this.log(`added protocolo w/ id=${protocolo.id}`)),
      catchError(this.handleError<Protocolo>('addProtocolo'))
    );
  }
  /** DELETE: delete the protocolo from the server */
  deleteProtocolo (protocolo: Protocolo | number): Observable<Protocolo> {
    const id = typeof protocolo === 'number' ? protocolo : protocolo.id;
    const url = `${this.protocolosUrl}/${id}`;
    return this.http.delete<Protocolo>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted protocolo id=${id}`)),
      catchError(this.handleError<Protocolo>('deleteProtocolo'))
    );
  }
  /** PUT: update the protocolo on the server */
  updateProtocolo (protocolo: Protocolo): Observable<any> {
    return this.http.put(this.protocolosUrl, protocolo, httpOptions).pipe(
      tap(_ => this.log(`updated protocolo id=${protocolo.id}`)),
      catchError(this.handleError<any>('updateProtocolo'))
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

  /** Log a ProtocoloService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`ProtocoloService: ${message}`);
  }
}
);
}