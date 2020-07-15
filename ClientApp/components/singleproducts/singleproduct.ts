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
        this.productSingle();
        axios.get('api/sizes').then(response => {
            this.sizes = response.data
        }).catch(e => {
            console.log("error");
        })
    }
    productSingle() {
        
        this.prodSizes = [];
        this.id = this.$route.params.productId;
        console.log(this.id);
        axios.get('api/product/' + this.id).then(response => {
            this.product = response.data["product"];
            this.prodSizes = response.data["sizesProd"];
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
    saveSizesProduct() {
        this.formData.append("sizeId", this.size.sizeId)
        this.formData.append("productId", this.id)
        this.formData.append("count", this.size.count.toString())
        axios.post('api/singleProduct', this.formData).then(response => {
            this.$toasted.success(response.data + ' size!', {
                icon: {
                    name: 'watch',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "top-right",
                duration: 4000
            });

        }).then(response => {
            this.productSingle();
        }).catch(e => {
            console.log("error");
        })
    }
}
