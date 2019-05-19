import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

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

  public predict(matchId: string): Observable<boolean> {
    return this.http.get<boolean>(
      `${environment.apiLink}/prediction/predict/${matchId}`
    );
  }

}
