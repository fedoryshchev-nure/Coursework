import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

import { TeamService } from 'src/app/services/team.service';

import { Team } from 'src/app/models/team';

@Component({
  selector: 'app-edit-team',
  templateUrl: './edit-team.component.html',
  styleUrls: ['./edit-team.component.css']
})
export class EditTeamComponent  implements OnInit, OnDestroy {
  public name = 'name';

  public errorOccurd = false;
  private teamId: string;

  private teamSubscription: Subscription;
  private createOrUpdateSubscription: Subscription;

  public teamForm = this.fb.group({
    name: ['', [Validators.required]]
  });

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private teamService: TeamService,
    private router: Router
  ) { }

  ngOnInit() {
    this.teamId = this.route.snapshot.paramMap.get('id');
    if (this.teamId)
      this.teamSubscription = this.teamService.getById(this.teamId).subscribe(
        team => this.teamForm.patchValue(team)
      );
  }

  public Submit() {
    if (this.teamForm.valid) {
      this.createOrUpdateSubscription = this.teamService.createOrUpdate(
        Object.assign(new Team(), this.teamForm.value), 
        this.teamId
      ).subscribe(team => 
        this.router.navigateByUrl(`team/edit/${team.id}`), 
        () => this.errorOccurd = true
      );
    }
  }

  ngOnDestroy(): void {
    if (this.teamId)
      this.teamSubscription.unsubscribe();
    if (this.createOrUpdateSubscription)
      this.createOrUpdateSubscription.unsubscribe();
  }
}
