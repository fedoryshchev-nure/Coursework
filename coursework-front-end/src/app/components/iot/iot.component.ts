import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Subscription } from 'rxjs';

import { IotService } from 'src/app/services/iot.service';

import { IOT } from 'src/app/models/iot';

@Component({
  selector: 'app-iot',
  templateUrl: './iot.component.html',
  styleUrls: ['./iot.component.css']
})
export class IotComponent  implements OnInit, OnDestroy {
  public pulse = 'pulse';
  public pressure = 'pressure';
  public playerId = 'playerId';
  public matchId = 'matchId';

  private subscription: Subscription;

  public iotForm = this.fb.group({
    pulse: [''],
    pressure: [''],
    playerId: [''],
    matchId: ['']
  });

  constructor(
    private fb: FormBuilder,
    private iotService: IotService
  ) { }

  ngOnInit() {
  }

  public Submit() {
    if (this.iotForm.valid) {
      this.subscription = this.iotService.createOrUpdate(
        Object.assign(new IOT(), this.iotForm.value)
      ).subscribe();
    }
  }

  ngOnDestroy(): void {
    if (this.subscription)
      this.subscription.unsubscribe();
  }
}