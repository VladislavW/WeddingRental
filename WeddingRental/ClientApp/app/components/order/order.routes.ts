import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OrderComponent } from './order.component';
import { AuthorizedGuard } from "../core/guards/authorized.guard";
import { WithoutroleGuard } from "../core/guards/withoutrole.guard";

const routes: Routes = [
    {
        path: '',
        component: OrderComponent,
        canActivate: [AuthorizedGuard, WithoutroleGuard]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class OrderRoutes { }
