import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';

import {CatalogService} from '../core/services/catalog.service';
import {CatalogModel} from "../core/models/catalogModel";
import {AuthenticationService} from "../core/services/authentication.service";
import {OrderModel} from "../core/models/orderModel";
import {OrderService} from "../core/services/order.service ";

@Component({
    selector: 'order',
    templateUrl: './order.component.html'
})
export class OrderComponent implements OnInit {

    products: CatalogModel[];
    order: OrderModel;

    orderNumber: string;
    
    newProduct: CatalogModel;
    
    constructor(
        private catalogService: CatalogService,
        private orderService: OrderService,
        private authenticationService: AuthenticationService,
        private router: Router,
        private activatedRoute: ActivatedRoute
    ) {

    }

    ngOnInit(): void {
       this.orderService.getOrder().subscribe((ord)=>{
           this.order = ord;
           this.orderNumber = this.order.orderNumber;
           this.loadProducts( this.order.orderId);
       });
    }
    
    loadProducts(orderId: number):void{
        var that = this;
        this.catalogService
            .gerProductsByOrder(orderId)
            .subscribe((items) => {
                that.products = items.json();
            });
    }

    submitOrder(orderId: number):void{
        this.orderService
            .submitOrder(orderId)
            .subscribe();
    }
}