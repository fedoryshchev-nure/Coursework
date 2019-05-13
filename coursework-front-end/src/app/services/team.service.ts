import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { GenericApiCallService } from './generic-api-call.service';

import { Team } from '../models/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService extends GenericApiCallService<Team> {

  constructor(
    http: HttpClient
  ) {
    super(http, "Team");
  }
}