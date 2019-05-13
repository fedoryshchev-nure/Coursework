import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { GenericApiCallService } from './generic-api-call.service';

import { Game } from '../models/game';

@Injectable({
  providedIn: 'root'
})
export class GameService extends GenericApiCallService<Game> {

  constructor(
    http: HttpClient
  ) {
    super(http, "Game");
  }
}
