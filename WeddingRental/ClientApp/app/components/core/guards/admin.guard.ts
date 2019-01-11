import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/first';

import { AuthenticationService } from '../services/authentication.service';


@Injectable()
export class AdminGuard implements CanActivate {
    constructor(private router: Router,
                private authenticationService: AuthenticationService) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
        return this.authenticationService.getPermission()
            .map((role: any) => {
                let isAdmin: any;
                if (role === 'admin') {
                    isAdmin = true;
                } else {
                    this.router.navigate(['/']);
                    isAdmin = false;
                }

                return isAdmin;
            }).first();
    }
}
