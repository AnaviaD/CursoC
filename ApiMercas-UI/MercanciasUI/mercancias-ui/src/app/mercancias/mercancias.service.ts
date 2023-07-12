import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MercanciasService {

  private baseUrl='https://localhost:44343'

  constructor(private httpClient: HttpClient) {}
  
  getAllMercancias():Observable<any>{
    return this.httpClient.get<any>(this.baseUrl + '/Mercancia');
  }
  
}
