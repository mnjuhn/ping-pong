import { Component, OnInit, NgModule } from '@angular/core';
import { Deserializable } from './deserializable.model';


export class PlayerModel implements Deserializable {

    public firstName: string = "asfasf";
    public lastName: string;
    public age: Number;
    public skillLevel: 'Beginner' | 'Intermediate' | 'Advanced' | 'Expert';
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
