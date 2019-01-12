import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {KeysPipe} from "../core/pipes/keys-pipe";



@NgModule({
    declarations: [KeysPipe],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,

    ],

    exports: [
        CommonModule,
        KeysPipe,
        FormsModule,
        ReactiveFormsModule,
        RouterModule
    ]
})
export class SharedModule {
}
