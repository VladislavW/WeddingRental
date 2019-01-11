import {Injectable} from '@angular/core';
import "rxjs/add/operator/map";
import {HttpInterceptor} from "../interceptor/HttpInterceptor";
import {CatalogModel} from "../models/catalogModel";
import {Observable} from "rxjs";


@Injectable()
export class CatalogService {
    public returnUrl: string = '';
    private readonly actionUrl: string;


    constructor(private http: HttpInterceptor){
        this.actionUrl = 'api/order';
    }

   // getOrders(){
   //     return this.http.get(this.actionUrl + '/get')
   //         .map((model: any) => {
   //             return model.json();
   //         });
   // }

    getOrder(userId: number){
        return this.http.get(this.actionUrl + '/get/'+ userId)
            .map((model: any) => {
                return model.json();
            });
    }

    addToOrder(product: CatalogModel): Observable<any>{
        return this.http.put(this.actionUrl + '/put', product);
    }

    submitOrder(): Observable<any>{
        return this.http.get(this.actionUrl + '/submit');
    }
}