import { Component } from '@angular/core';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
})
export class ServerComponent {
  serverId = 10;
  serverStatus = 'offline';
  disabledStatus = true;

  getServerStatus() {
    return this.serverStatus;
  }

  getDisabledStatus() {
    return this.disabledStatus;
  }
}
