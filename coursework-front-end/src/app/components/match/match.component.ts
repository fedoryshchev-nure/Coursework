import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';

import { AuthService } from 'src/app/services/auth.service';
import { MatchService } from 'src/app/services/match.service';

import { Match } from 'src/app/models/match';
import { MatchResult } from 'src/app/models/match-result-enum';

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.css']
})
export class MatchComponent implements OnInit, OnDestroy {
  matchId: string;
  match$: Observable<Match>;

  firstTeamWin: boolean;

  deleteSubscription: Subscription;
  predictionScubscription: Subscription;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private matchService: MatchService,
    public authService: AuthService
  ) { }

  ngOnInit() {
    this.matchId = this.route.snapshot.params['id'];
    this.match$ = this.matchService.getById(this.matchId)
      .pipe(
        map(x => x ? x : Match.mock())
      );
  }

  public predict() {
    this.predictionScubscription = this.matchService.predict(this.matchId).subscribe(
      firstTeamWin =>  this.firstTeamWin = firstTeamWin 
    );
  }

  public Delete(id: string) {
    this.deleteSubscription = this.matchService.delete(id).subscribe(
      () => this.router.navigateByUrl(`matches`), 
      () => alert('Not deleted')
    );
  }

  public getEnumKeyByValue(value: number): string {
    return MatchResult[value];
  }

  ngOnDestroy(): void {
    if (this.predictionScubscription)
      this.predictionScubscription.unsubscribe();
    if (this.deleteSubscription)
      this.deleteSubscription.unsubscribe();
  }
}
