import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'leagueFilter'
})
export class LeagueFilterPipe implements PipeTransform {

  transform(teams: any[], league: string): any[]{
    if(!teams)
      return null;
    if(!league)
      return teams;

    return teams.filter(team => {
      return team.league.name.includes(league);
    });
  }

}
