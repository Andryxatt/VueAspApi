import { IProduct, Product } from "./product.model";

export interface ISingleProduct  {
         product?:IProduct
         sizes: string[]
}
export class SingleProduct implements ISingleProduct {
    product = new Product();
    count = 0;
    sizes = [];
}