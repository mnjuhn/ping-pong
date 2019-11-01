import { Component, OnInit, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from '../app.component';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, FormControl, FormGroupDirective } from '@angular/forms';
import { PlayerService } from '../services/player';
import { PlayerModel } from './player.model';

@Component({
    selector: 'app-player',
    templateUrl: './player.editor.html',
    styleUrls: ['./player.component.css']
})

@NgModule({
    imports: [
        FormGroup,
        FormBuilder,
        FormsModule,
        ReactiveFormsModule,
        FormControl
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ]
})

export class PlayerInsert implements OnInit {

    public playerId: number;

    public player: PlayerModel;

    public playerForm: FormGroup;

    constructor(fb: FormBuilder, private playerService: PlayerService) {
        this.playerForm = fb.group({
            firstName: '',
            lastName: '',
            age: '',
            skillLevel: '',
            email: ''
        })
    }

    ngOnInit() {
        this.getPlayer();
    }

    public getPlayer() {
        this.playerService.getPlayer(this.playerId).subscribe(player => this.player = player);
    }

    public insertPlayer() {
        this.playerService.insertPlayer(this.player).subscribe(player => this.player = player);
    }

    submitForm(player) {

        if (player.email && player.firstName && player.lastName && player.skillLevel) {
            this.player = player;
            this.insertPlayer();
        }
    }
}
