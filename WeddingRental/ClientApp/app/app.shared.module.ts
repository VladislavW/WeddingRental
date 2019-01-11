import { NgModule } from '@angular/core';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import {CoreModule} from "./components/core/core.module";
import {SharedModule} from "./components/shared/shared.module";
import {HttpModule} from "@angular/http";
import { AppRoutes } from './app.routes';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
    ],
    
    imports: [
        AppRoutes,
        CoreModule.forRoot(),
        HttpModule,
        SharedModule
    ]
})
export class AppModuleShared {
}
