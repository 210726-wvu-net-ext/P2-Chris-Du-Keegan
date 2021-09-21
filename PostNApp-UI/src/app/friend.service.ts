import { Injectable } from '@angular/core';
import { IFriend } from './interfaces/friend';
import { observable, Observable, of, throwError} from 'rxjs';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { Router } from '@angular/router';
import { baseUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FriendService {

  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  private friendsUrl = `${baseUrl}friends`;
 
  constructor(
    private http: HttpClient,
    private router: Router
    ) { }

  getFriends(): Observable<IFriend[]>
  {
    return this.http.get<IFriend[]>(this.friendsUrl)
      .pipe(
        //tap(_ => this.log('fetched users')),
        catchError(this.handleError<IFriend[]>('getFriends', [])
      ));
  }

  getFriend(id: number): Observable<IFriend>
  {
    const url = `${this.friendsUrl}/${id}`;
    return this.http.get<IFriend>(url)
            .pipe(
              //tap(_ => this.log(`fetched user id=${id}`)),
              catchError(this.handleError<IFriend>(`getIFriend id={id}`))
            );
    
  }

  /** POST: add a new user to the server */
  addUser(friend: IFriend): Observable<IFriend>{
    return this.http.post<IFriend>(this.friendsUrl, friend, this.httpOptions).pipe(
      //tap((newUser: User) => this.log(`added hero w/ id=${newUser.id}`)),
      catchError(this.handleError1));
  }
  
  handleError1(error: HttpErrorResponse){
    
   return throwError(error.error);
  }

  /** PUT: update the user on the server */
  updateUser(id: number, user: IFriend): Observable<any> {
    const url = `${this.friendsUrl}/${id}`;
    return this.http.put<IFriend>(url, user, this.httpOptions).pipe(
      //tap(_ => this.log(`updated user id=${user.id}`)),
      catchError(this.handleError<any>('updateUser'))
    );
  }

  /** DELETE: delete the user from the server */
deleteUser(id: number): Observable<IFriend> {
  const url = `${this.friendsUrl}/${id}`;

  return this.http.delete<IFriend>(url, this.httpOptions).pipe(
    //tap(_ => this.log(`deleted user id=${id}`)),
    catchError(this.handleError<IFriend>('deleteUser'))
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
