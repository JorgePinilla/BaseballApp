import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'positionFilter'
})
export class PositionFilterPipe implements PipeTransform {

  transform(players: any[], position: string): any[] {
    if(!players)
      return null;
    if(!position)
      return players;

    return players.filter(player => {
      return player.position.abbreviation == position;
    });
  }

}
