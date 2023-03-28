import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-airport-data',
  templateUrl: './airport-data.component.html',
  styleUrls: ['./airport-data.component.scss']
})
export class AirportDataComponent implements OnInit{

  activeTabId: any;
  
  constructor(private activatedRoute: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
  }
}
