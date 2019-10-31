import { Component } from '@angular/core';
import { PlayerModel } from './player/player.model';
import { PlayerService } from './services/player';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
   title = 'PingPong';

    constructor() {
    }

}
