import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import { GameService } from 'src/app/services/game.service';

import { Game } from 'src/app/models/game';

@Component({
  selector: 'app-edit-game',
  templateUrl: './edit-game.component.html',
  styleUrls: ['./edit-game.component.css']
})
export class EditGameComponent implements OnInit, OnDestroy {
  public name = 'name';
  public description = 'description';

  public errorOccurd = false;
  private gameId: string;

  private gameSubscription: Subscription;
  private createOrUpdateSubscription: Subscription;

  public gameForm = this.fb.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]]
  });

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private gameService: GameService,
    private router: Router
  ) { }

  ngOnInit() {
    this.gameId = this.route.snapshot.paramMap.get('id');
    if (this.gameId)
      this.gameSubscription = this.gameService.getById(this.gameId).subscribe(
        game => this.gameForm.patchValue(game)
      );
  }

  public Submit() {
    if (this.gameForm.valid) {
      this.createOrUpdateSubscription = this.gameService.createOrUpdate(
        Object.assign(new Game(), this.gameForm.value), 
        this.gameId
      ).subscribe(game => 
        this.router.navigateByUrl(`game/edit/${game.id}`), 
        () => this.errorOccurd = true
      );
    }
  }

  ngOnDestroy(): void {
    if (this.gameId)
      this.gameSubscription.unsubscribe();
    if (this.createOrUpdateSubscription)
      this.createOrUpdateSubscription.unsubscribe();
  }
}
