import { Component, OnInit, NgModule, Inject } from '@angular/core';
import { PlayerService } from '../services/player';
import { ActivatedRoute } from '@angular/router';
import { AlertModule } from 'ngx-bootstrap';
import { Renderer } from '@angular/core';
import * as $ from 'jquery';

@Component({
    selector: 'app-player',
    templateUrl: './player.delete.html',
    styleUrls: ['./player.component.css']
})

@NgModule({
    imports: [
        AlertModule
    ]
})
export class PlayerDelete implements OnInit {

    public playerId: number;

    constructor(private playerService: PlayerService, private route: ActivatedRoute, private renderer: Renderer) {
    }

    ngOnInit() {
        // get player Id from URL
        this.playerId = +this.route.snapshot.paramMap.get('Id');
        // open modal window
        this.openDialog();
    }

    public deletePlayer() {
        this.playerService.deletePlayer(this.playerId).subscribe();
        // redirect to main page
        location.replace('/player');
    }

    openDialog() {
        $('#deleteModal').show();
    }
}
