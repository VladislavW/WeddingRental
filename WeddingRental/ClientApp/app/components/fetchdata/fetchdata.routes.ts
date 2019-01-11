import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FetchDataComponent } from './fetchdata.component';
import {AuthorizedGuard} from "../core/guards/authorized.guard";
import {AdminGuard} from "../core/guards/admin.guard";

const routes: Routes = [
    {
        path: '',
        component: FetchDataComponent,
        canActivate: [AuthorizedGuard, AdminGuard]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FetchdataRoutes { }
