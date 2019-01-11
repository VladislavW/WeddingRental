import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { OrderRoutes } from './order.routes';
import { OrderComponent } from './order.component';

@NgModule({
    imports: [
        SharedModule,
        OrderRoutes
    ],

    declarations: [
        OrderComponent
    ],

    exports: [
        OrderComponent
    ]
})
export class OrderModule {}
