import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { AuthRoutes } from './auth.routes';
import { AuthComponent } from './auth.component';

@NgModule({
    imports: [
        SharedModule,
        AuthRoutes
    ],

    declarations: [
        AuthComponent
    ],

    exports: [
        AuthComponent
    ]
})
export class AuthModule {}
