import Vue from 'vue';
import { Component, Watch, Emit, Prop } from 'vue-property-decorator';
import axios from 'axios';
import { IProduct, Product } from '../../data/models/product.model'
import { Carousel, Slide } from 'vue-carousel';
import { IProdSize, ProdSize } from '../../data/models/size.model';
@Component({
    components: {
        Carousel,
        Slide,
    }
})

export default class SingleProductComponent extends Vue {
    public id = '';
    public product = new Product();
    public formData = new FormData();
    public sizes: Array<ProdSize> = [];
    public prodSizes: Array<ProdSize> = [];
    public excludeSizes: Array<ProdSize> = [];
    saveSizes = [{}];
    qrCode = {};
    isDisable = true;
    size = new ProdSize();
    mounted() {
        axios.get('api/sizes').then(response => {
            this.sizes = response.data
        }).catch(e => {
            console.log("error");
        })
        this.productSingle();
    }
  
    productSingle() {
        var self = this;
        this.prodSizes = [];
        this.id = this.$route.params.productId;
        axios.get('api/product/' + this.id).then(response => {
            this.product = response.data["product"];
            this.prodSizes = response.data["sizesProd"];
        }).catch(e => {
            console.log("error");
        })
    }

    chekedValue(item) {
        (document.getElementById(item) as HTMLInputElement).disabled ? (document.getElementById(item) as HTMLInputElement).disabled = false : (document.getElementById(item) as HTMLInputElement).disabled = true;
    }

    showEdit(product: Product) {
        this.product = product;
    }

    returnUrl(obj): string {
        var url = 'data:image/jpeg;base64,' + obj;
        return url;
    }

    saveSizesProduct() {
        this.saveSizes.splice(0, 1);
        var selectedSizes = document.getElementsByClassName("count-size");
        for (var i = 0; i < selectedSizes.length; i++) {
            var size = {
                productId: this.id,
                sizeId: selectedSizes[i]['id'],
                count: selectedSizes[i]['value']
            }
            if (size.count > 0) {
                this.saveSizes.push(size);
            }
        };

        axios.post('api/singleProduct', this.saveSizes).then(response => {
            this.$toasted.success(response.data + ' size!', {
                icon: {
                    name: 'watch',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "top-right",
                duration: 4000
            })
            this.saveSizes = [];
        })
    }
}
