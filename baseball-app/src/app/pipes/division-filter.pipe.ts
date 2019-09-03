import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'divisionFilter'
})
export class DivisionFilterPipe implements PipeTransform {

  transform(teams: any[], division: string): any[] {
    if(!teams)
      return null;
    if(!division)
      return teams;
    
    return teams.filter(team => {
      return team.division.name.includes(division);
    });
  }

}
