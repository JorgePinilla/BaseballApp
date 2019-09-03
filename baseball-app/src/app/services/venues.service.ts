import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Venue } from '../classes/venue';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VenuesService {
  venuesApiURL: string = 'http://localhost:5000/api/venues';

  constructor(private httpClient: HttpClient) { }

  public getVenues(): Observable<Venue[]> {
    return this.httpClient.get<Venue[]>(this.venuesApiURL)
      .pipe(
        tap(_ => this.log('fetched Venues'),
        catchError(this.handleError<Venue[]>('getVenues', []))
        )
      )
  }

  public getVenueById(id: number): Observable<Venue> {
    const url = `${this.venuesApiURL}/${id}`;
    return this.httpClient.get<Venue>(url)
    .pipe(
      tap(_ => this.log(`fetched Venue id=${id}`),
      catchError(this.handleError<Venue>(`getVenueById id=${id}`))
      )
    )
  }

  /*Handle Http operation that failed.
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

  //Log Venue Service sessage
  private log(message: string){
    console.log(`Venues Service: ${message}`);
  }
}
