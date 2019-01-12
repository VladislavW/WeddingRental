import { Injectable } from '@angular/core';
import {
    Http,
    ConnectionBackend,
    RequestOptions,
    RequestOptionsArgs,
    Response,
    Headers
} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

declare var jquery:any;
declare var $ :any;

import {LocalStorageService} from "../services/local-storage.service";

@Injectable()
export class HttpInterceptor extends Http {
  
    constructor(
        backend: ConnectionBackend,
        defaultOptions: RequestOptions
    ) {
        super(backend, defaultOptions);
    }

    get(url: string, options?: RequestOptionsArgs): Observable<any> {
           return super.get(url, this.requestOptions(options))
            .catch(HttpInterceptor.onCatch)
            .do((res: Response) => {
                HttpInterceptor.onSuccess(res);
            }, (error: any) => {
                HttpInterceptor.onError(error);
            })
            .finally(() => {
                this.onFinally();
            });
    }

    post(url: string, body: any,  options?: RequestOptionsArgs): Observable<any> {
        return super.post(url, body, this.requestOptions(options))
            .catch(HttpInterceptor.onCatch)
            .do((res: Response) => {
                HttpInterceptor.onSuccess(res);
            }, (error: any) => {
                HttpInterceptor.onError(error);
            })
            .finally(() => {
                this.onFinally();
            });
    }

    put(url: string, body: any,  options?: RequestOptionsArgs): Observable<any> {
        return super.put(url, body, this.requestOptions(options))
            .catch(HttpInterceptor.onCatch)
            .do((res: Response) => {
                HttpInterceptor.onSuccess(res);
            }, (error: any) => {
                HttpInterceptor.onError(error);
            })
            .finally(() => {
                this.onFinally();
            });
    }


    // Implement POST, PUT, DELETE HERE

    /**
     * Request options.
     * @param options
     * @returns {RequestOptionsArgs}
     */
    private requestOptions(options?: RequestOptionsArgs): RequestOptionsArgs {
        if (options == null) {
            options = new RequestOptions();
        }
        if (options.headers == null) {
          //  const t = this.localStorageService.get('access_token');

            options.headers = new Headers({
                'Authorization': `Basic http://localhost:49750/`,
                'X-Auth-Token': ''
            });
        }
        return options;
    }


    /**
     * Error handler.
     * @param error
     * @param caught
     * @returns {ErrorObservable}
     */
    private static onCatch(error: any, caught: Observable<any>): Observable<any> {
        console.log(error);
        return Observable.throw(error);
    }

    /**
     * onSuccess
     * @param res
     */
    private static onSuccess(res: Response): void {
        console.log("ok")
       // this.notifyService.alertSuccess("OK");
    }

    /**
     * onError
     * @param error
     */
    private static onError(error: any): void {
            $("#error").html(error.statusText);
            $('#myModal').modal("show");
        //this.notifyService.alertWarning(error.statusText);
    }

    /**
     * onFinally
     */
    private onFinally(): void {
       
    }
}