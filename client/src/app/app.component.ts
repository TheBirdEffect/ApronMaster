import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  constructor(private http:HttpClient) {}

  
  ngOnInit(): void {
  }


  
}
