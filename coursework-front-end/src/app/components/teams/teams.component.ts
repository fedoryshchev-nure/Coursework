import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { TeamService } from 'src/app/services/team.service';

import { Team } from 'src/app/models/team';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css']
})
export class TeamsComponent implements OnInit {
  teams$: Observable<Team[]>;

  constructor(
    private teamService: TeamService
  ) { }

  ngOnInit() {
    this.teams$ = this.teamService.get();
  }

}

