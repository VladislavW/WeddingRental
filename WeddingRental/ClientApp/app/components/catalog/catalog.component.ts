import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';

import {CatalogService} from '../core/services/catalog.service';
import {CatalogModel} from "../core/models/catalogModel";
import {AuthenticationService} from "../core/services/authentication.service";
import {OrderService} from "../core/services/order.service ";
import {LocalStorageService} from "../core/services/local-storage.service";

@Component({
    selector: 'catalog',
    templateUrl: './catalog.component.html'
})
export class CatalogComponent implements OnInit {

    products: CatalogModel[];
    
    showAddNewProductBlock: boolean;
    
    newProduct: CatalogModel;
    productName: string;
    productNumber: string;
    
    showAddButtons: boolean;
    
    constructor(
        private catalogService: CatalogService,
        private orderService: OrderService,
        private authenticationService: AuthenticationService,
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private localStorageService: LocalStorageService
    ) {

    }

    ngOnInit(): void { 
       
        this.loadProducts();        

        this.authenticationService
            .isAuthorized()
            .subscribe((auth: any) => {
                const isAuthenticated = auth.json().isAuthenticated;
                if(isAuthenticated){
                    this.authenticationService.getPermission()
                        .subscribe((role: any) => {
                            this.showAddNewProductBlock = !!role && role.toLowerCase() === 'admin';
                            
                            this.showAddButtons =  !this.showAddNewProductBlock && isAuthenticated;
                        });
                }
            })
            
    }
    
    loadProducts():void{
        var that = this;
        this.catalogService
            .getProducts()
            .subscribe((items) => {
                that.products = items;
            });
    }

    addNewProduct():void{
        this.newProduct = new CatalogModel();
        this.newProduct.productNumber = this.productNumber;
        this.newProduct.productName = this.productName;        
        this.catalogService.addNewProduct(this.newProduct).subscribe(()=> this.loadProducts());
    }

    addToOrder(product: CatalogModel):void{    
        var mod = {
            productId : product.productId          
        };
        
        this.orderService
            .addToOrder(mod)
            .subscribe((item)=>{
                this.router.navigate(['/order']);
            });
    }

    
}