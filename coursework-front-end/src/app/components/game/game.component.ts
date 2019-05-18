import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';

import { AuthService } from 'src/app/services/auth.service';
import { GameService } from 'src/app/services/game.service';

import { Game } from 'src/app/models/game';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  game$: Observable<Game>;
  deleteSubscription: Subscription;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private gameService: GameService,
    public authService: AuthService
  ) { }

  ngOnInit() {
    const gameId = this.route.snapshot.params['id'];
    this.game$ = this.gameService.getById(gameId)
      .pipe(
        map(x => x ? x : Game.mock())
      );
  }

  public Delete(id: string) {
    this.deleteSubscription = this.gameService.delete(id).subscribe(
      () => this.router.navigateByUrl(`games`), 
      () => alert('Not deleted')
    );
  }

}
