import {Inject, Injectable} from '@angular/core';
import "rxjs/add/operator/map";
import {HttpInterceptor} from "../interceptor/HttpInterceptor";
import {CatalogModel} from "../models/catalogModel";
import {Observable} from "rxjs";


@Injectable()
export class CatalogService {
    public returnUrl: string = '';
    private readonly actionUrl: string;


    constructor(private http: HttpInterceptor) {
        this.actionUrl = 'api/product';
    }

   getProducts(){
       return this.http.get(this.actionUrl + '/get')
           .map((model: any) => {
               return model.json();
           });
   }

    addNewProduct(newProduct: CatalogModel): Observable<any> {
        return this.http.put(this.actionUrl + '/put', newProduct);
    }

    gerProductsByOrder(orderId : number): Observable<any>{
        return this.http.get(this.actionUrl + '/getByOrder/'+ orderId);
    }
}