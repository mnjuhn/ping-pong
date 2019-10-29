import { Component, OnInit, NgModule } from '@angular/core';
import { Deserializable } from './deserializable.model';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})

export class PlayerComponent implements OnInit, Deserializable {

    public firstName: string;
    public lastName: string;
    public age: Number;
    public skillLevel: 'Beginner' | 'Intermediate' | 'Advanced' | 'Expert';
    public email: string;

    constructor() {

    }

    ngOnInit() {

    }

    deserialize(input: any): this {
        Object.assign(this, input)

        return this;
    }

    getFullName() {
        return this.firstName + ' ' + this.lastName;
    }

}
