import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ServiceService {
  getDataAll() {
    throw new Error('Method not implemented.');
  }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };
  constructor(private http: HttpClient) {}
  getData() {
    return this.http.get('https://localhost:44344/api/Home/GetAllDetails');
  }
  postData(data: any) {
    let a = this.http
      .post('https://localhost:44344/api/Home/insert', data, this.httpOptions)
      .subscribe();
  }
  deleteData(data: number) {
    return this.http
      .delete('https://localhost:44344/api/Home/delete/'+data, this.httpOptions)
      .subscribe();
  }
}
