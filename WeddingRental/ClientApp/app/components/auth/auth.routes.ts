import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthComponent } from './auth.component';
import {UnauthrizedGuard} from "../core/guards/unauthorized.guard";

const routes: Routes = [
    {
        path: '',
        component: AuthComponent,
        canActivate: [UnauthrizedGuard]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AuthRoutes { }
