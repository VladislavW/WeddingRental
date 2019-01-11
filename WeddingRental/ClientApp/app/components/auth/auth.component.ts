import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthenticationService } from '../core/services/authentication.service';
//import { AlertService } from '../core/services/alert.service';
import { AuthManagerService } from '../core/services/auth.manager.service';
import { LocalStorageService } from '../core/services/local-storage.service';

import { LoginModel } from '../core/models/loginModel'

@Component({
    selector: 'auth',
    templateUrl: './auth.component.html'
})
export class AuthComponent{

    email: string;
    password: string;
    errorMessage: string;
    hideErrorMessage: boolean;


    customer = new LoginModel();
    
    constructor(
        private authenticationService: AuthenticationService,
        private router: Router,
        private authManagerService: AuthManagerService,
        private activatedRoute: ActivatedRoute,
        private localStorageService: LocalStorageService
    ) {

        this.hideErrorMessage = false;
        this.errorMessage = '';
    }

    signIn(): void {
        this.customer = {
            email: this.email,
            password: this.password
        };

        this.authenticationService
            .signIn(this.customer)
            .subscribe(
                (data) => {
                    this.authManagerService.authState.next(true);

                    this.authenticationService
                        .getPermission()
                        .subscribe((role: any) => {
                            const isAdmin = !!role && role.toLowerCase() === 'admin';
                            this.authManagerService.authIsAdmin.next(isAdmin);
                        });

                    if (!data.isContactExist) {
                        this.localStorageService.remove('firstName');
                        this.localStorageService.remove('lastName');
                    }
                    // if (this.authenticationService.returnUrl.length > 0) {
                    //     this.router.navigateByUrl(this.authenticationService.returnUrl);
                    //     this.authenticationService.returnUrl = '';
                    //     return;
                    // }

                    this.router.navigate(['/home']);
                });
    }


    parseFullName(fullName: string) {
        const nameModel = fullName.trim().split(' ');

        if (nameModel.length === 2) {
            this.localStorageService.set('firstName', nameModel[0], 30);
            this.localStorageService.set('lastName', nameModel[1], 30);
            return;
        }

        this.localStorageService.remove('firstName');
        this.localStorageService.remove('lastName');
    }
    
}