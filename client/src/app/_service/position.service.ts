import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, switchMap } from 'rxjs';
import { position } from '../_models/position';

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  private basicApiPath = "https://localhost:5001/api";

  constructor(private http:HttpClient) { }

  // GetPosition() {
  //   return this.http.get(this.basicApiPath + "/position");
  // }

  getPositions(): Observable<position[]> { 
    return this.http.get<position[]>(this.basicApiPath + "/position").pipe(
      map(response => {return response})
    )
  }

}

