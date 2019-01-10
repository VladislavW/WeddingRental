import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { HomeRoutes } from './home.routes';
import { HomeComponent } from './home.component';

@NgModule({
    imports: [
        SharedModule,
        HomeRoutes
    ],

    declarations: [
        HomeComponent
    ],

    exports: [
        HomeComponent
    ]
})
export class HomeModule {}
