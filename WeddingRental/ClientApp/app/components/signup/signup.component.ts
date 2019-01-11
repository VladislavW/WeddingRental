import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthenticationService } from '../core/services/authentication.service';

import { AuthManagerService } from '../core/services/auth.manager.service';
import { LocalStorageService } from '../core/services/local-storage.service';
import {SignUpModel} from "../core/models/signUpModel";


@Component({
    selector: 'signup',
    templateUrl: './signup.component.html'
})
export class SignUpComponent{

    email: string;
    password: string;
    confirmPassword: string;
    
    errorMessage: string;
    hideErrorMessage: boolean;


    customer = new SignUpModel();
    
    constructor(
        private authenticationService: AuthenticationService,
        private router: Router
    ) {

        this.hideErrorMessage = false;
        this.errorMessage = '';
    }

    signUp(): void {
        this.customer = {
            email: this.email,
            password: this.password,
            confirmPassword: this.confirmPassword
        };

        this.authenticationService
            .signUp(this.customer)
            .subscribe(
                (data) => {
                    this.router.navigate(['/auth']);
                });
    }    
}