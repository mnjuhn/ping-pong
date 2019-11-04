import { Component, OnInit, NgModule } from '@angular/core';
import { Deserializable } from './deserializable.model';



export class PlayerModel implements Deserializable {

    public skillLevels = ["Beginner", "Intermediate", "Advanced", "Expert"];

    public Id: Number;
    public firstName: string;
    public lastName: string;
    public age: number;
    public skillLevel: string;
    public email: string;

    constructor() {

    }

    deserialize(input: any): this {
        Object.assign(this, input)

        return this;
    }

    /* Validates all values of the player model */
    validate() {
        var errors: String[];
        errors = [];
        if (!this.firstName) {
            errors.push("First Name is required.");
        }
        if (!this.lastName) {
            errors.push("Last Name is required.");
        }
        if (!this.email) {
            errors.push("Email is required.");
        } else {
            // RegEX for evaluating email addresses
            var expression = RegExp('[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}', "i");
            if (!expression.test(this.email)) {
                errors.push("Improperly formatted email.")
            }
        }
        if (this.age) {
            if (isNaN(this.age)) {
                errors.push("Age must be a number.");
            }
        }
        if (this.skillLevel === null || this.skillLevel === undefined || this.skillLevel === '') {
            errors.push("Skill Level must be set.");
        }
        console.log(this.skillLevel);

        return errors;
    }

}
