import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { TeamsService } from '../services/teams.service';
import { Roster } from '../classes/roster';

@Component({
  selector: 'app-team-roster',
  templateUrl: './team-roster.component.html',
  styleUrls: ['./team-roster.component.css']
})
export class TeamRosterComponent implements OnInit {
  roster: Roster[];

  constructor(
    private teamService: TeamsService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getRoster();
  }

  getRoster(): void {
    const id = +this.route.parent.snapshot.paramMap.get('id');
    this.teamService.GetRoster(id).subscribe(roster => this.roster = roster);
  }
}
