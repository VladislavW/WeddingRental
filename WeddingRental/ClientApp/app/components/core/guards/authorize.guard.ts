import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthenticationService } from '../services/authentication.service';
import { AuthManagerService } from '../services/auth.manager.service';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/first';

@Injectable()
export class AuthorizeGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private authManagerService: AuthManagerService
    ) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        return this.authenticationService
            .isAuthorized()
            .map((auth: any) => {
                const isAuthenticated = auth.json().isAuthenticated;

                this.authManagerService.authState.next(isAuthenticated);

                if (!isAuthenticated) {
                    this.authenticationService.returnUrl = state.url;
                    this.router.navigate(['/login']);
                }

                return isAuthenticated;
            })
            .first();
    }
}
