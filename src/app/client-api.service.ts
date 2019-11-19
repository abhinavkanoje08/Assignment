import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IClients } from './Clients';


const httpheader =
{
  headers: new HttpHeaders({ 'Content-Type': "application/json" })
}


@Injectable({
  providedIn: 'root'

})

export class ClientApiService {
  private baseUrl: string = 'https://localhost:44363/api/Clients/';


  constructor(private http: HttpClient) { }


  printResult(clients: IClients): Observable<IClients[]> {

    let NameUrl = `${this.baseUrl}`
    if (clients.FirstName != undefined) {
      NameUrl = `${NameUrl}${clients.FirstName}/`;
    }


    if (clients.LastName != undefined) {
      NameUrl = `${NameUrl}${clients.LastName}`;
    }

    console.log(NameUrl);
    return this.http.get<IClients[]>(NameUrl, httpheader);
  }

}




