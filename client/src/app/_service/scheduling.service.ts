import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SchedulingService {

  private basicApiPath = "https://localhost:5001/api/Schedule";

  constructor(public http:HttpClient) { }



  public initializeScheduling() {
    return this.http.get(this.basicApiPath + "/inititialize").subscribe();
  }
}
