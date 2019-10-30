import { Component } from '@angular/core';
import { PlayerComponent } from './player/player.component';
import { PlayerService } from './services/player';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
   title = 'PingPong';


    public playerId: number;

    public player: PlayerComponent;

    public players: PlayerComponent[];

    constructor(private playerService: PlayerService) {
        this.getAllUsers();
    }

    public getUser() {
        this.playerService.getPlayer(this.playerId).subscribe(player => this.player = player);
    }

    public getAllUsers() {
        this.playerService.getAllPlayers().subscribe(players => {
            this.players = players
        });
    }
}
