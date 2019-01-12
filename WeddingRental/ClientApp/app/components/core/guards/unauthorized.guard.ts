import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { AuthenticationService } from '../services/authentication.service';
import { AuthManagerService } from '../services/auth.manager.service';

@Injectable()
export class UnauthrizedGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private authManagerService: AuthManagerService
    ) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        return this.authenticationService.isAuthorized()
            .map((auth: any) => {
                const isAuthorized = auth.json().isAuthenticated;

                this.authManagerService.authState.next(isAuthorized);

                if (isAuthorized) {
                    this.router.navigate(['/']);
                }

                return !isAuthorized;
            });
    }
}