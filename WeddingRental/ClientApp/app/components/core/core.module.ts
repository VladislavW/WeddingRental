import { ModuleWithProviders, NgModule, Optional, SkipSelf } from '@angular/core';

import { AuthenticationService } from './services/authentication.service';
import { AuthManagerService } from './services/auth.manager.service';
import { LocalStorageService } from './services/local-storage.service';

import { AdminGuard } from './guards/admin.guard';
import { AuthorizedGuard } from './guards/authorized.guard';
import { UnauthrizedGuard } from './guards/unauthorized.guard';
import { AuthorizeGuard } from './guards/authorize.guard';

import {SharedModule} from "../shared/shared.module";
import {HttpInterceptor} from "./interceptor/HttpInterceptor";
import {RequestOptions, XHRBackend} from "@angular/http";
import {ToastyConfig, ToastyService} from "ng2-toasty";
import {CatalogService} from "./services/catalog.service";
import {OrderService} from "./services/order.service ";

@NgModule({
    imports: [
        SharedModule
    ]
})

export class CoreModule {
    
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: CoreModule,
            providers: [
                LocalStorageService,
                ToastyConfig,
                ToastyService,
                AuthManagerService,
                AuthenticationService,
                CatalogService,
                OrderService,
                AdminGuard,
                AuthorizedGuard,
                UnauthrizedGuard,
                AuthorizeGuard,
                {
                    provide: HttpInterceptor,
                    useFactory:
                        (backend: XHRBackend, defaultOptions: RequestOptions) => {
                            return new HttpInterceptor(backend, defaultOptions);
                        },
                    deps: [ XHRBackend, RequestOptions]
                },
            ]
        };
    }

    constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
        if (parentModule) {
            throw new Error('CoreModule is already loaded. Import it in the AppModule only');
        }
    }
}