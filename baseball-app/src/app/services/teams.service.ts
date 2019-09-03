import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Team } from '../classes/team';
import { Roster } from '../classes/roster';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TeamsService {
  teamsApiURL: string = 'http://localhost:5000/api/teams';

  constructor(private httpClient: HttpClient) { }

  public getTeams() : Observable<Team[]> {
    return this.httpClient.get<Team[]>(this.teamsApiURL)
      .pipe(
        tap(_ => this.log('fetched teams'),
        catchError(this.handleError<Team[]>('getTeams', []))
        )
      )
  }

  public getTeamById(id: number) : Observable<Team> {
    const url = `${this.teamsApiURL}/${id}`;
    return this.httpClient.get<Team>(url)
      .pipe(
        tap(_ => this.log(`fetched team id=${id}`),
        catchError(this.handleError<Team>(`getTeamById id=${id}`))
        )
      )
  }

  public GetRoster(id: number) : Observable<Roster[]> {
    const url = `${this.teamsApiURL}/${id}/roster`;
    return this.httpClient.get<Roster[]>(url)
      .pipe(
        tap(_ => this.log(`fetched team id=${id} roster`),
        catchError(this.handleError<Team>(`getRoster teamid=${id}`))
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

  //Log Team Service sessage
  private log(message: string){
    console.log(`Teams Service: ${message}`);
  }
  
}
