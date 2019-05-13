import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { GameService } from 'src/app/services/game.service';

import { Game } from 'src/app/models/game';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {
  games$: Observable<Game[]>;

  constructor(
    private gameService: GameService
  ) { }

  ngOnInit() {
    this.games$ = this.gameService.get();
  }

}
