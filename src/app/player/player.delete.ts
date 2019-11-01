import { Component, OnInit, NgModule } from '@angular/core';
import { PlayerService } from '../services/player';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-player',
    templateUrl: './player.delete.html',
    styleUrls: ['./player.component.css']
})

export class PlayerDelete implements OnInit {

    public playerId: number;

    constructor(private playerService: PlayerService, private route: ActivatedRoute) {
    }

    ngOnInit() {
        // get player Id from URL
        this.playerId = +this.route.snapshot.paramMap.get('Id');
        alert(this.playerId);
        this.deletePlayer();
    }

    public deletePlayer() {
        alert(this.playerId);
        this.playerService.deletePlayer(this.playerId).subscribe();
    }
}
