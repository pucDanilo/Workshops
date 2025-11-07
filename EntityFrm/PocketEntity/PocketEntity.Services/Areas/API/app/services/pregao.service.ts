import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Pregao } from './models/Pregao';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class PregaoService {

  private pregaosUrl = 'api/pregaos';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET pregaos from the server */
  getPregaos (): Observable<Pregao[]> {
    return this.http.get<Pregao[]>(this.pregaosUrl)
      .pipe(
        tap(pregaos => this.log('fetched pregaos')),
        catchError(this.handleError('getPregaos', []))
      );
  }

  /** GET pregao by id. Return `undefined` when id not found */
  getPregaoNo404<Data>(id: number): Observable<Pregao> {
    const url = `${this.pregaosUrl}/?id=${id}`;
    return this.http.get<Pregao[]>(url)
      .pipe(
        map(pregaos => pregaos[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} pregao id=${id}`);
        }),
        catchError(this.handleError<Pregao>(`getPregao id=${id}`))
      );
  }
  /** GET pregao by id. Will 404 if id not found */
  getPregao(id: number): Observable<Pregao> {
    const url = `${this.pregaosUrl}/${id}`;
    return this.http.get<Pregao>(url).pipe(
      tap(_ => this.log(`fetched pregao id=${id}`)),
      catchError(this.handleError<Pregao>(`getPregao id=${id}`))
    );
  }

  /* GET pregaos whose name contains search term */
  searchPregaos(term: string): Observable<Pregao[]> {
    if (!term.trim()) {
      // if not search term, return empty pregao array.
      return of([]);
    }

    return this.http.get<Pregao[]>(`${this.pregaosUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found pregaos matching "${term}"`)),
      catchError(this.handleError<Pregao[]>('searchPregaos', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new pregao to the server */
  addPregao (pregao: Pregao): Observable<Pregao> {
    return this.http.post<Pregao>(this.pregaosUrl, pregao, httpOptions).pipe(
      tap((pregao: Pregao) => this.log(`added pregao w/ id=${pregao.id}`)),
      catchError(this.handleError<Pregao>('addPregao'))
    );
  }
  /** DELETE: delete the pregao from the server */
  deletePregao (pregao: Pregao | number): Observable<Pregao> {
    const id = typeof pregao === 'number' ? pregao : pregao.id;
    const url = `${this.pregaosUrl}/${id}`;
    return this.http.delete<Pregao>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted pregao id=${id}`)),
      catchError(this.handleError<Pregao>('deletePregao'))
    );
  }
  /** PUT: update the pregao on the server */
  updatePregao (pregao: Pregao): Observable<any> {
    return this.http.put(this.pregaosUrl, pregao, httpOptions).pipe(
      tap(_ => this.log(`updated pregao id=${pregao.id}`)),
      catchError(this.handleError<any>('updatePregao'))
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

  /** Log a PregaoService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`PregaoService: ${message}`);
  }
}
);
}