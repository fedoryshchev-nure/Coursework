import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { PlayerService } from 'src/app/services/player.service';

import { Player } from 'src/app/models/player';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {
  players$: Observable<Player[]>;

  constructor(
    private playerService: PlayerService
  ) { }

  ngOnInit() {
    this.players$ = this.playerService.get();
  }

}