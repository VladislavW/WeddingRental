import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { FetchdataRoutes } from './fetchdata.routes';
import { FetchDataComponent } from './fetchdata.component';

@NgModule({
    imports: [
        SharedModule,
        FetchdataRoutes
    ],

    declarations: [
        FetchDataComponent
    ],

    exports: [
        FetchDataComponent
    ]
})
export class FetchDataModule {}
