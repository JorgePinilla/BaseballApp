import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { PlayersService } from '../services/players.service';
import { Constants } from '../classes/constants';
import { Player } from '../classes/player';
import { Stat } from '../classes/stat';

@Component({
  selector: 'app-player-details',
  templateUrl: './player-details.component.html',
  styleUrls: ['./player-details.component.css']
})
export class PlayerDetailsComponent implements OnInit {
  player: Player;
  hittingStats: Stat[];
  pitchingStats: Stat[];
  fieldingStats: Stat[];
  hittingStat: Stat = null;
  pitchingStat: Stat = null;
  fieldingStat: Stat = null;

  constructor(
    private playerService: PlayersService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getPlayer();
    this.getHittingStats();
    this.getPitchingStats();
    this.getFieldingStats();
    window.scrollTo(0, 0);
  }

  getPlayer() : void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.playerService.getPlayerById(id).subscribe(player => this.player = player);
  }
  
  getHittingStats() : void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.playerService.getPlayerStatsByGroup(id, Constants.HITTING)
        .subscribe(stats => this.hittingStats = stats);
  }

  getPitchingStats() : void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.playerService.getPlayerStatsByGroup(id, Constants.PITCHING)
        .subscribe(stats => this.pitchingStats = stats);
  }

  getFieldingStats() : void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.playerService.getPlayerStatsByGroup(id, Constants.FIELDING)
        .subscribe(stats => this.fieldingStats = stats);
  }
}
