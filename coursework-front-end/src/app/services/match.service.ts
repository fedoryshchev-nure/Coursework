import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { GenericApiCallService } from './generic-api-call.service';

import { Match } from '../models/match';

@Injectable({
  providedIn: 'root'
})
export class MatchService extends GenericApiCallService<Match>{

  constructor(
    http: HttpClient
  ) {
    super(http, "Match");
  }

}
