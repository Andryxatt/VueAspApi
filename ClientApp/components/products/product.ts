import Vue from 'vue';
import { Component, Watch, Emit } from 'vue-property-decorator';
import axios from 'axios';
import { IProduct, Product } from '../../data/models/product.model'
import { IBrand } from '../../data/models/brand.model';
import { Carousel, Slide } from 'vue-carousel';
import PhotoComponent from '../photo/photo';
import { BCard } from 'bootstrap-vue'
import NewProductComponent from '../newproduct/newproduct';
import EditProductComponent from '../editproduct/editproduct';

@Component({
    components: {
        Carousel,
        Slide,
        PhotoComponent,
        NewProductComponent,
        EditProductComponent,
        BCard
    }
})

export default class ProductComponent extends Vue {
    rows= 100
    perPage = 8
    currentPage = 1
    hasNext = false
    hasPrev = false
    products: IProduct[] = []
    brands: IBrand[] = []
    product = new Product()
    productId = ''
    showEditKey = false
    search=''
    public formData = new FormData();
    mounted() {
        this.AllProducts();
        axios.get('api/brands').then(responnse => {
            this.brands = responnse.data;
        })
    }
   
    showEdit(product: Product) {
        this.product = product;
        this.showEditKey = true;
    }
    nextPage() {
        if (this.hasNext)
            this.currentPage++;

        this.AllProducts();
    }
    prevPage() {
        if (this.hasPrev) 
            this.currentPage--;
        
        this.AllProducts();
    }
     AllProducts():void {
         axios.get('api/product?pageNumber=' + this.currentPage + '&pageSize=' + this.perPage +'&searchString=' + this.search + '').then(response => {
            this.products = response.data;
            this.rows = JSON.parse(response.headers['x-pagination'])['TotalPages'];
            this.currentPage = JSON.parse(response.headers['x-pagination'])['CurrentPage'];
            this.hasNext = JSON.parse(response.headers['x-pagination'])['HasNext'];
            this.hasPrev = JSON.parse(response.headers['x-pagination'])['HasPrevious'];
        }).catch(e => {
            console.log("error");
        })
    }

    returnUrl(obj): string {
        var url = 'data:image/jpeg;base64,' + obj;
        return url;
    }
    deleteProduct(id: string): void {
        axios.delete('api/product/' + id).then(response => {
            this.$toasted.info(response.data + ' succesful!', {
                icon: {
                    name: 'watch',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "top-right",
                duration: 3000
            });
            this.AllProducts();
        }).catch(e => {
            console.log("error");
        })

    }

}
