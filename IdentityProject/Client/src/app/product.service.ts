import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap, switchMap, debounceTime } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Product } from '../models/Product';
import { Token } from '../models/Token';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private ProductUrl = './IdentityProject/Products/GetProducts';

  private AccountUrl = './IdentityProject/Account/GetAntiForgeryToken';

 // token: Token;

  constructor(private http: HttpClient) {
   // this.token = new Token();
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }

  private log(message: string) {
    console.log('StudyService: ' + message);
  }

  getProducts(token:Token): Observable<Product[]> {
  /*  return this.getAntiForgeryToken().pipe(switchMap(data => {
      console.log(data);
      if (data.cookieToken.length !== 0) {
        this.token = data;
        var ab = this.http.get<Product[]>(this.ProductUrl, { headers: new HttpHeaders({ 'X_CSRF_TOKEN': JSON.parse(JSON.stringify(data)) }) })
          .pipe(
            tap(products => this.log(`fetched products`)),
            catchError(this.handleError('getProducts', [])),
          );
        return ab;
      }
      return ab;

}));*/

    if (token.cookieToken.length != 0) {
      return this.http.get<Product[]>(this.ProductUrl, { headers: new HttpHeaders({ 'X_CSRF_TOKEN': token.cookieToken + ":"+ token.formToken }) })
        .pipe(
          tap(products => this.log(`fetched products`)),
          catchError(this.handleError('getProducts', [])),
        );
    }



  }

  getAntiForgeryToken(): Observable<Token> {
    return this.http.get<any>(this.AccountUrl)
      .pipe(
        tap(token => this.log(`fetched token`)),
      catchError(this.handleError('getAntiForgeryToken', [])),
      );
  }

}
