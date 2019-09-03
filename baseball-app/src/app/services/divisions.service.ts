import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Division } from '../classes/division';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DivisionsService {
  divisionsApiURL: string = 'http://localhost:5000/api/divisions';

  constructor(private httpClient: HttpClient) { }

  public getDivisions() : Observable<Division[]> {
    return this.httpClient.get<Division[]>(this.divisionsApiURL)
      .pipe(
        tap(_ => this.log('fetched divisions'),
        catchError(this.handleError<Division[]>('getDivisions', []))
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

  //Log Division Service sessage
  private log(message: string){
    console.log(`Divisions Service: ${message}`);
  }
}
