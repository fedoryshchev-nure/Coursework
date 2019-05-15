import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { MatchService } from 'src/app/services/match.service';

import { Match } from 'src/app/models/match';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.css']
})
export class MatchesComponent implements OnInit {
  matches$: Observable<Match[]>;

  constructor(
    private matchService: MatchService
  ) { }

  ngOnInit() {
    this.matches$ = this.matchService.get().pipe(        
      tap(resp => console.log(resp))
    );
  }

}