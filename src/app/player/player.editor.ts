import { Component, OnInit, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from '../app.component';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, FormControl, FormGroupDirective } from '@angular/forms';
import { PlayerService } from '../services/player';
import { PlayerModel } from './player.model';
import { ActivatedRoute } from '@angular/router';

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

export class PlayerEditor implements OnInit {

    public playerId: number;

    public player: PlayerModel;

    public playerForm: FormGroup;


    constructor(fb: FormBuilder, private playerService: PlayerService, private route: ActivatedRoute) {
        this.playerForm = fb.group({
            firstName: '',
            lastName: '',
            age: '',
            email: '',
            skillLevel: ''
        })
    }

    ngOnInit() {
        // get player Id from URL
        this.playerId = +this.route.snapshot.paramMap.get('Id');
        this.getPlayer();
    }

    public getPlayer() {
        this.playerService.getPlayer(this.playerId).subscribe(player => { this.player = player; this.updateTemplate() } );
    }

    private updateTemplate() {
        this.playerForm.get("firstName").setValue(this.player.firstName);
        this.playerForm.get("lastName").setValue(this.player.lastName);
        this.playerForm.get("age").setValue(this.player.age);
        this.playerForm.get("email").setValue(this.player.email);
        this.playerForm.get("skillLevel").setValue(this.player.skillLevel);
    }

    public updatePlayer() {
        this.playerService.updatePlayer(this.player).subscribe();
    }

    submitForm(player) {
        player.Id = this.playerId;
        if (player.email && player.firstName && player.lastName) {

            this.player = player;
            this.updatePlayer();
        }
        // redirect to main page
        location.replace('/player');
    }
}
