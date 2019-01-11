import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { CatalogRoutes } from './catalog.routes';
import { CatalogComponent } from './catalog.component';

@NgModule({
    imports: [
        SharedModule,
        CatalogRoutes
    ],

    declarations: [
        CatalogComponent
    ],

    exports: [
        CatalogComponent
    ]
})
export class CatalogModule {}
