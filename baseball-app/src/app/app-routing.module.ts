import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TeamsComponent } from './teams/teams.component';
import { PlayersComponent } from './players/players.component';
import { VenuesComponent } from './venues/venues.component';
import { TeamDetailsComponent } from './team-details/team-details.component';
import { TeamOverviewComponent } from './team-overview/team-overview.component';
import { TeamRosterComponent } from './team-roster/team-roster.component';
import { TeamStatsComponent } from './team-stats/team-stats.component';
import { PlayerDetailsComponent } from './player-details/player-details.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'teams', component: TeamsComponent},
  {path: 'players', component: PlayersComponent},
  {path: 'venues', component: VenuesComponent},
  {path: 'players/:id', component: PlayerDetailsComponent},
  {path: 'teams/:id', component: TeamDetailsComponent,
    children: [
      {path: '', component: TeamOverviewComponent},
      {path: 'overview', component: TeamOverviewComponent},
      {path: 'roster', component: TeamRosterComponent},
      {path: 'stats', component: TeamStatsComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
