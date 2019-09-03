import { Component, OnInit, HostListener } from '@angular/core';

import { PlayersService } from '../services/players.service';
import { PositionsService } from '../services/positions.service';
import { Player } from '../classes/player';
import { Position } from '../classes/position';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  players: Player[];
  positions: Position[];
  playerName: string = null;
  positionSelected: Position = null;
  perPage: number = 25;

  constructor(
    private playerService: PlayersService,
    private positionService: PositionsService
  ) { }

  @HostListener('window:scroll', ['$event'])
  onScrollEvent(event){
    let pos = document.documentElement.scrollTop;
    let scrollHeight = document.documentElement.clientHeight;
    let max = document.documentElement.scrollHeight;
  
    if(pos + scrollHeight >= max){
      this.perPage += 25;
    }
  }

  ngOnInit() {
    this.getPlayers();
    this.getPositions();
  }

  getPlayers(): void {
    this.playerService.getPlayers().subscribe(players => this.players = players);
  }

  getPositions(): void {
    this.positionService.getPositions().subscribe(positions => this.positions = positions);
  }

  resetPageSize(): void {
    this.perPage = 25;
  }
}
