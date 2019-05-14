import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import { MatchService } from 'src/app/services/match.service';

import { Match } from 'src/app/models/match';
import { MatchResult } from 'src/app/models/match-result-enum';

@Component({
  selector: 'app-edit-match',
  templateUrl: './edit-match.component.html',
  styleUrls: ['./edit-match.component.css']
})
export class EditMatchComponent  implements OnInit, OnDestroy {
  public date = 'date';
  public result = 'result';
  public gameId = 'gameId';
  public teamOneId = 'teamOneId';
  public teamTwoId = 'teamTwoId';

  public possibleResults = this.enumToListNames(MatchResult);

  public errorOccurd = false;
  private matchId: string;

  private matchSubscription: Subscription;
  private createOrUpdateSubscription: Subscription;

  public matchForm = this.fb.group({
    date: [new Date(), [Validators.required]],
    result: [MatchResult.None, [Validators.required]],
    gameId: ['', [Validators.required]],
    teamOneId: ['', [Validators.required]],
    teamTwoId: ['', [Validators.required]]
  });

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private matchService: MatchService,
    private router: Router
  ) { }

  ngOnInit() {
    this.matchId = this.route.snapshot.paramMap.get('id');
    if (this.matchId)
      this.matchSubscription = this.matchService.getById(this.matchId).subscribe(
        match => this.matchForm.patchValue(match)
      );
  }

  public Submit() {
    if (this.matchForm.valid) {
      this.createOrUpdateSubscription = this.matchService.createOrUpdate(
        Object.assign(new Match(), this.matchForm.value), 
        this.matchId
      ).subscribe(match => 
        this.router.navigateByUrl(`match/edit/${match.id}`), 
        () => this.errorOccurd = true
      );
    }
  }

  ngOnDestroy(): void {
    if (this.matchId)
      this.matchSubscription.unsubscribe();
    if (this.createOrUpdateSubscription)
      this.createOrUpdateSubscription.unsubscribe();
  }

  private enumToListNames(en: any) : string[] {
    let keys = Object.keys(en)
      .filter(k => typeof en[k as any] === "number");
    
    return keys;
  }
}