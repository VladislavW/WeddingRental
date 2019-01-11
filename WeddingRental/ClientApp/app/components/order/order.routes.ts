import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OrderComponent } from './order.component';
import { AuthorizedGuard } from "../core/guards/authorized.guard";

const routes: Routes = [
    {
        path: '',
        component: OrderComponent,
        canActivate: [AuthorizedGuard] 
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class OrderRoutes { }
