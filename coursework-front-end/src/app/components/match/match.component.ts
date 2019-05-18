import { Component, OnInit } from '@angular/core';
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
export class MatchComponent implements OnInit {
  match$: Observable<Match>;
  deleteSubscription: Subscription;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private matchService: MatchService,
    public authService: AuthService
  ) { }

  ngOnInit() {
    const matchId = this.route.snapshot.params['id'];
    this.match$ = this.matchService.getById(matchId)
      .pipe(
        map(x => x ? x : Match.mock())
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
}
