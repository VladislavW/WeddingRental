import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import {CatalogModel, Color, ProductType} from "../core/models/catalogModel";
import {EnumExtension} from "../core/models/enumExtension";

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: CatalogModel[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/product/getTop').subscribe(result => {
            this.forecasts = result.json() as CatalogModel[];
        }, error => console.error(error));
    }

    colorToString(color: Color){
        return EnumExtension.colorToString(color);
    }

    typeToString(type: ProductType){
        return EnumExtension.typeToString(type);
    }

}
