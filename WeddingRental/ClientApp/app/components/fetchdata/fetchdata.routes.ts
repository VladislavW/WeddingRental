import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FetchDataComponent } from './fetchdata.component';
import {AuthorizedGuard} from "../core/guards/authorized.guard";

const routes: Routes = [
    {
        path: '',
        component: FetchDataComponent,
        canActivate: [AuthorizedGuard]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FetchdataRoutes { }
