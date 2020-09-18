export interface IProduct {
    productId?: string
    model?: string
    priceBy?: number
    brandId?: number
    subId?: number
    countBoxes: number
    countPairsInBox: number
    sizesInBox:string
    photos?: string[]
    brand?: object
    sizes?: string[]
    priceSalleUS?: number
    priceSalleUAH?: number
    isDiscount?: boolean
    discountUS?: number
    discountUAH?:number
}
export class Product implements IProduct {
    brandId;
    model;
    photos = [];
    priceBy;
    productId;
    subId;
    brand = {};
    sizes = [];
    countBoxes;
    countPairsInBox;
    sizesInBox;
    discountUAH;
    discountUS;
    isDiscount = false;
    priceSalleUAH;
    priceSalleUS;

    
}