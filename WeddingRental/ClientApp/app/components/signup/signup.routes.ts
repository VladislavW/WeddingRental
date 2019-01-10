import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SignUpComponent } from './signup.component';
import {UnauthrizedGuard} from "../core/guards/unauthorized.guard";

const routes: Routes = [
    {
        path: '',
        component: SignUpComponent,
        canActivate: [UnauthrizedGuard]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SignUpRoutes { }
