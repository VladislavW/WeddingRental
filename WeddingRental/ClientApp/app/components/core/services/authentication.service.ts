import { Injectable } from '@angular/core';
import { LoginModel } from '../models/loginModel';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import "rxjs/add/operator/map";
import {HttpInterceptor} from "../interceptor/HttpInterceptor";
import {SignUpModel} from "../models/signUpModel";

@Injectable()
export class AuthenticationService {
    public returnUrl: string = '';
    private readonly actionUrl: string;

    private isLoggedIn: boolean = false;

    constructor(private http: HttpInterceptor) {
        this.actionUrl = 'api/user';
    }

    isAuthorized(): Observable<any> {
        return this.http
            .get(this.actionUrl + '/isauthenticated')
            .do(value => this.isLoggedIn = true);
    }

    getPermission() {
        return this.http.get(this.actionUrl + '/claims')
            .map((claims: any) => {
                let role: any;
                claims.map((item: any) => {
                    if (item.type === 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role') {
                        role = item.value;
                    }
                });
                return role;
            });
    }

    signIn(customer: LoginModel): Observable<any> {
        return this.http.post(this.actionUrl + '/signIn', customer);
    }

    signUp(customer: SignUpModel): Observable<any> {
        return this.http.post(this.actionUrl + '/signUp', customer);
    }

    signOut() {
        return this.http.post(this.actionUrl + '/signOut', null);
    }
}