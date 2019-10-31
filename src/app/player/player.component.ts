import { Component, OnInit, NgModule } from '@angular/core';
import { PlayerService } from '../services/player';
import { PlayerModel } from './player.model';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})

export class PlayerComponent implements OnInit {

    public playerId: number;

    public player: PlayerModel;

    public players: PlayerModel[];

    constructor(private playerService: PlayerService) {

    }

    ngOnInit() {
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
