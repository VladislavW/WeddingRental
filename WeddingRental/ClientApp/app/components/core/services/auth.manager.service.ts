import { Injectable, Input } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthManagerService {
    private authStateSubject = new BehaviorSubject<boolean>(false);
    public authState = this.authStateSubject;

    private authIsAdminSubject = new BehaviorSubject<boolean>(false);
    public authIsAdmin = this.authIsAdminSubject;
}
