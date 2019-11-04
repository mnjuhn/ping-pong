import { Component, OnInit, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppComponent } from '../app.component';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, FormControl, FormGroupDirective } from '@angular/forms';
import { PlayerService } from '../services/player';
import { PlayerModel } from './player.model';

@Component({
    selector: 'app-player',
    templateUrl: './player.insert.html',
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

    public errors: String[];

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
        this.player = new PlayerModel();
    }

    public insertPlayer() {
        this.playerService.insertPlayer(this.player).subscribe(player => this.player = player);
    }

    submitForm(player) {
    
        this.player.firstName = player.firstName;
        this.player.lastName = player.lastName;
        this.player.email = player.email;
        this.player.age = player.age;
        this.player.skillLevel = player.skillLevel;

        this.errors = this.player.validate();

        // if no errors insert player otherwise show errors in form
        if (this.errors && this.errors.length > 0) {

        } else {
            this.insertPlayer();
            // redirect to main page
            location.replace('/player');
        }
    }
}
