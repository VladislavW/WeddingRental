import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home.component';
import { AuthorizedGuard } from '../core/guards/authorized.guard';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent//,
       // canActivate: [AuthorizedGuard]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomeRoutes { }
