import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Player } from '../classes/player';
import { Stat } from '../classes/stat';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {
  playersApiUrl = 'http://localhost:5000/api/people';

  constructor(private httpClient: HttpClient) { }

  public getPlayers() : Observable<Player[]> {
    return this.httpClient.get<Player[]>(this.playersApiUrl)
      .pipe(
        tap(_ => this.log('fetched Players'),
        catchError(this.handleError<Player[]>('getPlayers', []))
        )
      )
  }

  public getPlayerById(id: number) : Observable<Player>{
    const url = `${this.playersApiUrl}/${id}`;
    return this.httpClient.get<Player>(url)
      .pipe(
        tap(_ => this.log(`fetched player id=${id}`),
        catchError(this.handleError<Player>(`getPlayerById id=${id}`))
        )
      )
  }

  public getPlayerStatsByGroup(id: number, statGroup: string) : Observable<Stat[]> {
    const url = `${this.playersApiUrl}/${id}/stats/${statGroup}`;
    return this.httpClient.get<Stat[]>(url)
      .pipe(
        tap(_ => this.log(`fetched player stats id=${id} statGroup=${statGroup}`),
        catchError(this.handleError<Stat[]>(`getPlayerStatsByGroup id=${id} statGroup=${statGroup}`))
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

  //Log Player Service sessage
  private log(message: string){
    console.log(`Playes Service: ${message}`);
  }
}
