import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { SignUpRoutes } from './signup.routes';
import { SignUpComponent } from './signup.component';

@NgModule({
    imports: [
        SharedModule,
        SignUpRoutes
    ],

    declarations: [
        SignUpComponent
    ],

    exports: [
        SignUpComponent
    ]
})
export class SignUpModule {}
