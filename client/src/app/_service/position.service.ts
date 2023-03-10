import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  private basicApiPath = "https://localhost:5001/api";

  constructor(private http:HttpClient) { }

  GetPosition() {
    return this.http.get(this.basicApiPath + "/position");
  }

}

