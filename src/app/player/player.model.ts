import { Component, OnInit, NgModule } from '@angular/core';
import { Deserializable } from './deserializable.model';



export class PlayerModel implements Deserializable {

    public skillLevels = ["Beginner", "Intermediate", "Advanced", "Expert"];

    public Id: Number;
    public firstName: string;
    public lastName: string;
    public age: Number;
    public skillLevel: string;
    public email: string;

    constructor() {

    }

    deserialize(input: any): this {
        Object.assign(this, input)

        return this;
    }

    getFullName() {
        return this.firstName + ' ' + this.lastName;
    }

}
