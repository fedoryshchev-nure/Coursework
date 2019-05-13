import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { GenericApiCallService } from './generic-api-call.service';

import { Player } from '../models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayerService extends GenericApiCallService<Player> {

  constructor(
    http: HttpClient
  ) {
    super(http, "Player");
  }
}
