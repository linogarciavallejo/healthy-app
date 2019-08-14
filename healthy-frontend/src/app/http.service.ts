import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }

  getUser(userId: any) {
    return this.http.get('https://localhost:5001/api/User/' + userId);
  }

  getEventsLog(userId: any) {
    // return this.http.get('https://localhost:5001/api/User');
    return this.http.get('https://localhost:5001/api/eventslog/' + userId);
  }
}
