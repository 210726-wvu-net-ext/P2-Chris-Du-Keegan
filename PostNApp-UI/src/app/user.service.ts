import { Injectable } from '@angular/core';
import { User } from './interfaces/user';

import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private usersUrl = 'https://localhost:44365/api/User';
  constructor(
    private http: HttpClient,
  ) { }

  getUsers(): Observable<User[]>
  {
    return this.http.get<User[]>(this.usersUrl)
      .pipe(
        //tap(_ => this.log('fetched users')),
        catchError(this.handleError<User[]>('getUsers', []))
      );
  }
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getUser(id: number): Observable<User>
  {
    const url = `${this.usersUrl}/${id}`;
    return this.http.get<User>(url)
      .pipe(
      //tap(_ => this.log(`fetched hero id=${id}`)),
      catchError(this.handleError<User>(`getUser id=${id}`))
    );
  }
}
