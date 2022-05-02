import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product, ServiceResponseProduct } from './product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = "https://localhost:7276/api/Product";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient : HttpClient) { 
  }

  getAll(): Observable<Product[]>{
    return this.httpClient.get<Product[]>(this.apiUrl + '/GetProducts/')
    .pipe(catchError(this.errorHandler))
  }

  create(product: Product): Observable<ServiceResponseProduct> {
    return this.httpClient.post<ServiceResponseProduct>(this.apiUrl + '/Create/', JSON.stringify(product), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }  
    
  find(productId: number): Observable<ServiceResponseProduct> {
    return this.httpClient.get<ServiceResponseProduct>(this.apiUrl + '/GetProduct?productId=' + productId)
    .pipe(
      catchError(this.errorHandler)
    )
  }
    
  update(product: Product): Observable<ServiceResponseProduct> {
    return this.httpClient.put<ServiceResponseProduct>(this.apiUrl + '/Update/', JSON.stringify(product), this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }
    
  delete(productId: number){
    return this.httpClient.delete<Product>(this.apiUrl + '/posts/' + productId, this.httpOptions)
    .pipe(
      catchError(this.errorHandler)
    )
  }

  errorHandler(error: { error: { message: string; }; status: any; message: any; }) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }

    return throwError(errorMessage);
 }
}
