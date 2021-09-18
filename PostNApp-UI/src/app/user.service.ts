import { Injectable } from '@angular/core';
import { User } from './interfaces/user';
import { Observable, of} from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  private usersUrl = 'https://localhost:44365/api/users';
 
  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]>
  {
    return this.http.get<User[]>(this.usersUrl)
      .pipe(
        //tap(_ => this.log('fetched users')),
        catchError(this.handleError<User[]>('getUsers', [])
      ));
  }

  getUser(id: number): Observable<User>
  {
    const url = `${this.usersUrl}/${id}`;
    return this.http.get<User>(url)
            .pipe(
              //tap(_ => this.log(`fetched user id=${id}`)),
              catchError(this.handleError<User>(`getUser id={id}`))
            );
    
  }

  /** POST: add a new hero to the server */
  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.usersUrl, user, this.httpOptions).pipe(
      //tap((newUser: User) => this.log(`added hero w/ id=${newUser.id}`)),
      catchError(this.handleError<User>('addUser'))
    );
  }

  /** PUT: update the hero on the server */
  updateUser(id: number, user: User): Observable<any> {
    const url = `${this.usersUrl}/${id}`;
    return this.http.put<User>(url, user, this.httpOptions).pipe(
      //tap(_ => this.log(`updated hero id=${hero.id}`)),
      catchError(this.handleError<any>('updateUser'))
    );
  }

  /** DELETE: delete the hero from the server */
deleteUser(id: number): Observable<User> {
  const url = `${this.usersUrl}/${id}`;

  return this.http.delete<User>(url, this.httpOptions).pipe(
    //tap(_ => this.log(`deleted hero id=${id}`)),
    catchError(this.handleError<User>('deleteUser'))
  );
}

    /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      //this.log(`${operation} failed: ${error.message}`);
      console.log(operation); //create message service

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
