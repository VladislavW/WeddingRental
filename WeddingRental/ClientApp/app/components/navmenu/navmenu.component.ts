import {Component, Input, OnInit} from '@angular/core';


import { AuthenticationService } from '../core/services/authentication.service'
import { AuthManagerService } from '../core/services/auth.manager.service';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import {Router} from "@angular/router";


@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent implements OnInit {
    private isAuthorizedSubject = new BehaviorSubject<boolean>(false);
    private isAdminSubject = new BehaviorSubject<boolean>(false);

    @Input()
    set isAuthorized(value) {
        this.isAuthorizedSubject.next(value);
    };

    get isAuthorized() {
        return this.isAuthorizedSubject.getValue();
    }

    @Input()
    set isAdmin(value) {
        this.isAdminSubject.next(value);
    };

    get isAdmin() {
        return this.isAdminSubject.getValue();
    }

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private authManagerService: AuthManagerService
    ) {
    }

    ngOnInit(): void {
        this.authManagerService
            .authState
            .subscribe((authState) => {
                this.isAuthorized = authState;
            });

        this.authManagerService
            .authIsAdmin
            .subscribe((authState) => {
                this.isAdmin = authState;
            });
    }
    
    signOut(): void{
        this.authenticationService
            .signOut()
            .subscribe((data) => {
                this.router.navigate(['/home']);
            });
    }
    
    
}
