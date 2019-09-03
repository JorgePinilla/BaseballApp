import { Pipe, PipeTransform } from '@angular/core';
import { ValueTransformer } from '@angular/compiler/src/util';

@Pipe({
  name: 'searchTeam'
})
export class SearchTeamPipe implements PipeTransform {

  transform(teams: any[], name: string): any[] {
    if(!teams)
      return null;
    if(!name)
      return teams;

    name = name.toLowerCase();

    return teams.filter(team => {
      return team.name.toLowerCase().includes(name);
    });
  }

}
