import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchPlayer'
})
export class SearchPlayerPipe implements PipeTransform {

  transform(players: any[], name: string): any[] {
    if(!players)
      return null;
    if(!name)
      return players;

    name = name.toLowerCase();

    return players.filter(player => {
      return player.fullName.toLowerCase().includes(name);
    });
  }

}
