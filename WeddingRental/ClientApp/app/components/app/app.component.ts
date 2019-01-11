import { OnInit, Component } from '@angular/core';

import { AuthenticationService } from '../core/services/authentication.service'
import { AuthManagerService } from '../core/services/auth.manager.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    isAuthorized: boolean;

    constructor(
        private authenticationService: AuthenticationService,
        private authManagerService: AuthManagerService
    ) {
        this.isAuthorized = false;
    }

    ngOnInit() {
        this.authenticationService.isAuthorized()
            .subscribe((auth: any) => {
                const isAuthenticated = auth.json().isAuthenticated;

                this.authManagerService.authState.next(isAuthenticated);

                if (isAuthenticated) {
                    this.authenticationService
                        .getPermission()
                        .subscribe((role: any) => {
                            const isAdmin = !!role && role.toLowerCase() === 'admin';
                            this.authManagerService.authIsAdmin.next(isAdmin);
                        });
                }
            });
    }
}
