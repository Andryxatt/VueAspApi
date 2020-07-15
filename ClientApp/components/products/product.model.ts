export interface IProduct {
    productId?: string
    model?: string
    priceBy?: number
    brandId?: number
    subId?: number
    photos?: string[]
    brand?: object
    sizes?: string[]
}
export class Product implements IProduct {
    brandId = 1;
    model = "";
    photos = [];
    priceBy = 0;
    productId = "";
    subId = 0;
    brand = {};
    sizes = [];
}