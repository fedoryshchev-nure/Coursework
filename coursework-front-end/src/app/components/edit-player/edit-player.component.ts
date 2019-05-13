import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import { PlayerService } from 'src/app/services/player.service';

import { Player } from 'src/app/models/player';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent implements OnInit, OnDestroy {
  public nickname = 'nickname';
  public firstName = 'firstName';
  public lasttName = 'lasttName';
  public dateOfBirth = 'dateOfBirth';
  public teamId = 'teamId';

  public errorOccurd = false;
  private playerId: string;

  private playerSubscription: Subscription;
  private createOrUpdateSubscription: Subscription;

  public playerForm = this.fb.group({
    nickname: ['', [Validators.required]],
    firstName: ['', [Validators.required]],
    lasttName: ['', [Validators.required]],
    dateOfBirth: [new Date(), [Validators.required]],
    teamId: ['', [Validators.required]]
  });

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private playerService: PlayerService,
    private router: Router
  ) { }

  ngOnInit() {
    this.playerId = this.route.snapshot.paramMap.get('id');
    if (this.playerId)
      this.playerSubscription = this.playerService.getById(this.playerId).subscribe(
        player => this.playerForm.patchValue(player)
      );
  }

  public Submit() {
    if (this.playerForm.valid) {
      this.createOrUpdateSubscription = this.playerService.createOrUpdate(
        Object.assign(new Player(), this.playerForm.value), 
        this.playerId
      ).subscribe(player => 
        this.router.navigateByUrl(`player/edit/${player.id}`), 
        () => this.errorOccurd = true
      );
    }
  }

  ngOnDestroy(): void {
    if (this.playerId)
      this.playerSubscription.unsubscribe();
    if (this.createOrUpdateSubscription)
      this.createOrUpdateSubscription.unsubscribe();
  }
}

