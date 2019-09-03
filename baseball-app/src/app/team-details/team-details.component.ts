import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { TeamsService } from '../services/teams.service';
import { Team } from '../classes/team';

@Component({
  selector: 'app-team-details',
  templateUrl: './team-details.component.html',
  styleUrls: ['./team-details.component.css']
})
export class TeamDetailsComponent implements OnInit {
  team : Team;

  constructor(
    private teamService: TeamsService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getTeam();
  }

  getTeam(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.teamService.getTeamById(id).subscribe(team => this.team = team);
  }
}
