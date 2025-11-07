import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Tenant } from './models/Tenant';
import { MessageService } from './message.service';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class TenantService {

  private tenantsUrl = 'api/tenants';  // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  /** GET tenants from the server */
  getTenants (): Observable<Tenant[]> {
    return this.http.get<Tenant[]>(this.tenantsUrl)
      .pipe(
        tap(tenants => this.log('fetched tenants')),
        catchError(this.handleError('getTenants', []))
      );
  }

  /** GET tenant by id. Return `undefined` when id not found */
  getTenantNo404<Data>(id: number): Observable<Tenant> {
    const url = `${this.tenantsUrl}/?id=${id}`;
    return this.http.get<Tenant[]>(url)
      .pipe(
        map(tenants => tenants[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} tenant id=${id}`);
        }),
        catchError(this.handleError<Tenant>(`getTenant id=${id}`))
      );
  }
  /** GET tenant by id. Will 404 if id not found */
  getTenant(id: number): Observable<Tenant> {
    const url = `${this.tenantsUrl}/${id}`;
    return this.http.get<Tenant>(url).pipe(
      tap(_ => this.log(`fetched tenant id=${id}`)),
      catchError(this.handleError<Tenant>(`getTenant id=${id}`))
    );
  }

  /* GET tenants whose name contains search term */
  searchTenants(term: string): Observable<Tenant[]> {
    if (!term.trim()) {
      // if not search term, return empty tenant array.
      return of([]);
    }

    return this.http.get<Tenant[]>(`${this.tenantsUrl}/?name=${term}`).pipe(
             tap(_ => this.log(`found tenants matching "${term}"`)),
      catchError(this.handleError<Tenant[]>('searchTenants', []))
    );
  }

  //////// Save methods //////////
  /** POST: add a new tenant to the server */
  addTenant (tenant: Tenant): Observable<Tenant> {
    return this.http.post<Tenant>(this.tenantsUrl, tenant, httpOptions).pipe(
      tap((tenant: Tenant) => this.log(`added tenant w/ id=${tenant.id}`)),
      catchError(this.handleError<Tenant>('addTenant'))
    );
  }
  /** DELETE: delete the tenant from the server */
  deleteTenant (tenant: Tenant | number): Observable<Tenant> {
    const id = typeof tenant === 'number' ? tenant : tenant.id;
    const url = `${this.tenantsUrl}/${id}`;
    return this.http.delete<Tenant>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted tenant id=${id}`)),
      catchError(this.handleError<Tenant>('deleteTenant'))
    );
  }
  /** PUT: update the tenant on the server */
  updateTenant (tenant: Tenant): Observable<any> {
    return this.http.put(this.tenantsUrl, tenant, httpOptions).pipe(
      tap(_ => this.log(`updated tenant id=${tenant.id}`)),
      catchError(this.handleError<any>('updateTenant'))
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

  /** Log a TenantService message with the MessageService */
  private log(message: string) {

    this.messageService.add(`TenantService: ${message}`);
  }
}
);
}