import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';

import { TeamService } from 'src/app/services/team.service';

import { Team } from 'src/app/models/team';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {
  team$: Observable<Team>;
  deleteSubscription: Subscription;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private teamService: TeamService
  ) { }

  ngOnInit() {
    const teamId = this.route.snapshot.params['id'];
    this.team$ = this.teamService.getById(teamId)
      .pipe(
        map(x => x ? x : Team.mock())
      );
  }

  public Delete(id: string) {
    this.deleteSubscription = this.teamService.delete(id).subscribe(
      () => this.router.navigateByUrl(`games`), 
      () => alert('Not deleted')
    );
  }

}
