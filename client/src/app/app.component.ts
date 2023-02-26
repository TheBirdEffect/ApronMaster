import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  constructor(private http:HttpClient) {}
  flights: any;

  title = "Client"
  
  ngOnInit(): void {
    this.http.get("https://localhost:5001/api/flight").subscribe({
      next: response => this.flights = response,
      error: error => console.log(error),
      complete: () => console.log("Response completed!")
    })
  }


  
}
