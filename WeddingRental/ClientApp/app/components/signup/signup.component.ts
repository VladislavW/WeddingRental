import { Component } from '@angular/core';
import { Router} from '@angular/router';

import { AuthenticationService } from '../core/services/authentication.service';

import {SignUpModel} from "../core/models/signUpModel";


@Component({
    selector: 'signup',
    templateUrl: './signup.component.html'
})
export class SignUpComponent{

    email: string;
    password: string;
    confirmpassword: string;
    
    errorMessage: string;
    hideErrorMessage: boolean;

    territories: {
        id: number,
        name: string
    }[];

    territoryid: number;
    
    customer : SignUpModel;
    
    constructor(
        private authenticationService: AuthenticationService,
        private router: Router
    ) {

        this.hideErrorMessage = false;
        this.errorMessage = '';

        this.authenticationService.getTerritories().subscribe((t: any)=>{
            this.territories = t.json();
        });
    }

    signUp(): void {
        this.customer = {
            email: this.email,
            password: this.password,
            confirmPassword: this.confirmpassword,
            territoryId: this.territoryid
        };

        this.authenticationService
            .signUp(this.customer)
            .subscribe(
                (data) => {
                    this.router.navigate(['/auth']);
                });
    }    
}