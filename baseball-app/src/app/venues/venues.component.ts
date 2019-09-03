import { Component, OnInit } from '@angular/core';

import { VenuesService } from '../services/venues.service';
import{ Venue } from '../classes/venue';

@Component({
  selector: 'app-venues',
  templateUrl: './venues.component.html',
  styleUrls: ['./venues.component.css']
})
export class VenuesComponent implements OnInit {
  venues: Venue[];

  constructor(private venueService: VenuesService) { }

  ngOnInit() {
    this.getVenues();
  }

  getVenues(): void {
    this.venueService.getVenues().subscribe(venues => this.venues = venues);
  }
}
