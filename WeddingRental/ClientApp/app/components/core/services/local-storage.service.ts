import { Injectable } from '@angular/core';

@Injectable()
export class LocalStorageService {
    private enabled(): boolean {
        try {
            localStorage.setItem('test-is-storage-enabled-key', '');
            localStorage.removeItem('test-is-storage-enabled-key');

            return true;
        } catch (error){
            return false;
        }
    }

    set(key: string, value: Object | string | number, expirationTimeout: number): boolean {
        if (!this.enabled()) {
            return false;
        }

        const storeObject: any = {
            val: value
        };

        if (expirationTimeout !== null) {
            storeObject.exp = expirationTimeout;
            storeObject.time = new Date().getTime();
        }

        localStorage.setItem(key, JSON.stringify(storeObject));

        return true;
    }

    get(key: string) {
        debugger;
        if (!this.enabled()) {
            return null;
        }

        const data = localStorage.getItem(key) || '';
        if (!data) {
            return null;
        }

        const object = JSON.parse(data);
        if (object.time != null) {
            if (new Date().getTime() - object.time > object.exp) {
                this.remove(key);
                return null;
            }
        }

        return object.val;
    }

    has(key: string) {
        if (!this.enabled()) {
            return false;
        }

        return localStorage.getItem(key) !== '';
    }

    remove(key: string) {
        if (!this.enabled()) {
            return false;
        }

        localStorage.removeItem(key);
        return true;
    }

    clear() {
        if (this.enabled()) {
            localStorage.clear();
        }
    }
}
