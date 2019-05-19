import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { GenericApiCallService } from './generic-api-call.service';

import { IOT } from '../models/iot';

@Injectable({
  providedIn: 'root'
})
export class IotService extends GenericApiCallService<IOT> {

  constructor(
    http: HttpClient
  ) {
    super(http, "BioMeasure");
  }
}