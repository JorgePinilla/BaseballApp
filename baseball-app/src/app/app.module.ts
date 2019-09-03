import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TeamsComponent } from './teams/teams.component';
import { PlayersComponent } from './players/players.component';
import { TeamDetailsComponent } from './team-details/team-details.component';
import { TeamOverviewComponent } from './team-overview/team-overview.component';
import { TeamRosterComponent } from './team-roster/team-roster.component';
import { TeamStatsComponent } from './team-stats/team-stats.component';
import { PlayerDetailsComponent } from './player-details/player-details.component';

import { LeagueFilterPipe } from './pipes/league-filter.pipe';
import { DivisionFilterPipe } from './pipes/division-filter.pipe';
import { SearchTeamPipe } from './pipes/search-team.pipe';
import { SearchPlayerPipe } from './pipes/search-player.pipe';
import { PositionFilterPipe } from './pipes/position-filter.pipe';
import { VenuesComponent } from './venues/venues.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TeamsComponent,
    PlayersComponent,
    TeamDetailsComponent,
    TeamOverviewComponent,
    TeamRosterComponent,
    TeamStatsComponent,
    PlayerDetailsComponent,
    LeagueFilterPipe,
    DivisionFilterPipe,
    PositionFilterPipe,
    SearchTeamPipe,
    SearchPlayerPipe,
    VenuesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
