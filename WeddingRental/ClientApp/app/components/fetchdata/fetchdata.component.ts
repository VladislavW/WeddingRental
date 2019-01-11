import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import {CatalogModel} from "../core/models/catalogModel";

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
}
