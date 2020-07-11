import Vue from 'vue';
import { Component, Watch, Emit, Prop } from 'vue-property-decorator';
import axios from 'axios';
import { IProduct, Product } from '../products/product.model'
import { IBrand } from '../brands/brand.model';
import { Carousel, Slide } from 'vue-carousel';
import PhotoComponent from '../photo/photo';
import NewProductComponent from '../newproduct/newproduct';
import EditProductComponent from '../editproduct/editproduct'
import { IProdSize, ProdSize } from '../sizeproduct/size.model';
@Component({
    components: {
        Carousel,
        Slide,
        PhotoComponent,
        NewProductComponent,
        EditProductComponent
    }
})
export default class SingleProductComponent extends Vue {
    public id = '';
    public product = new Product();
    public formData = new FormData();
    public sizes: ProdSize[] = [];
    public prodSizes = [];
    size = new ProdSize();
    mounted() {
        this.id = this.$route.params.productId;
        axios.get('api/product/' + this.id).then(response => {
            this.product = response.data["product"];
            this.prodSizes = response.data["sizesProd"]
        }).catch(e => {
            console.log("error");
        })
        axios.get('api/sizes').then(response => {
            this.sizes = response.data
        }).catch(e => {
            console.log("error");
        })

    }
    //get productsSizes(): string[] {
    //    

    //    axios.get('api/product/' + this.id).then(response => {
    //        this.prodSizes = response.data.sizesProd
    //        this.product = response.data.product
    //    }).catch(e => {
    //        console.log("error");
    //    })
    //    return this.prodSizes
    //}
    showEdit(product: Product) {
        this.product = product;
        
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
   
    saveSizesProduct() {
        this.formData.append("sizeId", this.size.sizeId)
        this.formData.append("productId", this.product.productId)
        this.formData.append("count", this.size.count.toString())
        axios.post('api/singleProduct', this.formData).then(response => {
            console.log("succes");
        }).catch(e => {
            console.log("error");
        })
    }
}
