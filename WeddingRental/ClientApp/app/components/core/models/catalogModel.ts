export class CatalogModel {
    public productName: string;
    public productNumber: string;
    public productId: number;
    public productColor: Color;
    public type: ProductType;    
}

export enum Color {
    White = 1,
    Blue = 2,
    Yellow = 3,
    Red = 4,
    Green = 5
}

export enum ProductType {
    Dress= 1,
    Veil = 2,
    Flowers = 3
}
