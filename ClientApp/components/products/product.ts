import Vue from 'vue';
import { Component, Watch, Emit } from 'vue-property-decorator';
import axios from 'axios';
import { IProduct, Product } from '../products/product.model'
import { IBrand } from '../brands/brand.model';
import { Carousel, Slide } from 'vue-carousel';
import PhotoComponent from '../photo/photo';
import NewProductComponent from '../newproduct/newproduct';
import EditProductComponent from '../editproduct/editproduct';

@Component({
    components: {
        Carousel,
        Slide,
        PhotoComponent,
        NewProductComponent,
        EditProductComponent
    }
})
export default class ProductComponent extends Vue {
    products: IProduct[] = [];
    brands: IBrand[] = [];
    product = new Product();
    brand = '';
    productId = '';
 
    showEditKey = false;
    public formData = new FormData();
    //get productsAll(): IProduct[] {
    //    axios.get('api/product').then(response => {
    //        this.products = response.data
    //    }).catch(e => {
    //        console.log("error");
    //    })
    //    return this.products
    //}
   
    mounted() {
       

        axios.get('api/product').then(response => {
            this.products = response.data
        }).catch(e => {
            console.log("error");
        })
    }
    showEdit(product: Product) {
        this.product = product;
        this.showEditKey = true;
       
    }
    returnUrl(obj): string {
        var url = 'data:image/jpeg;base64,' + obj;
        return url;
    }
    deleteProduct(id: string): void {
        axios.delete('api/product/' + id).then(response => {
            console.log("succes");
        }).catch(e => {
            console.log("error");
        })
        
    }
  
}
