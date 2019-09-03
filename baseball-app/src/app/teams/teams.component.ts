import { Component, OnInit } from '@angular/core';

import { TeamsService } from '../services/teams.service';
import { LeaguesService } from '../services/leagues.service';
import { DivisionsService } from '../services/divisions.service';
import { Team } from '../classes/team';
import { League } from '../classes/league';
import { Division } from '../classes/division';


@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  teams: Team[];
  leagues: League[];
  divisions: Division[];
  leagueSelected: League = null;
  divisionSelected: Division = null;
  teamName: string = null;

  constructor(
    private teamService: TeamsService,
    private leagueService: LeaguesService,
    private divisionService: DivisionsService
  ) { }

  ngOnInit() {
    this.getTeams();
    this.getLeagues();
    this.getDivisions();
  }

  getTeams(): void {
    this.teamService.getTeams().subscribe(teams => this.teams = teams);
  }

  getLeagues(): void {
    this.leagueService.getRegularLeagues().subscribe(leagues => this.leagues = leagues);
  }

  getDivisions(): void {
    this.divisionService.getDivisions().subscribe(divisions => this.divisions = divisions);
  }
}
