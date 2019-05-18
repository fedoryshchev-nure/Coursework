import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';

import { AuthService } from 'src/app/services/auth.service';
import { PlayerService } from 'src/app/services/player.service';

import { Player } from 'src/app/models/player';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  player$: Observable<Player>;
  deleteSubscription: Subscription;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private playerService: PlayerService,
    public authService: AuthService
  ) { }

  ngOnInit() {
    const playerId = this.route.snapshot.params['id'];
    this.player$ = this.playerService.getById(playerId)
      .pipe(
        map(x => x ? x : Player.mock())
      );
  }

  public Delete(id: string) {
    this.deleteSubscription = this.playerService.delete(id).subscribe(
      () => this.router.navigateByUrl(`players`), 
      () => alert('Not deleted')
    );
  }

}