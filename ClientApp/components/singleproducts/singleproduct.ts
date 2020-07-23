import Vue from 'vue';
import { Component, Watch, Emit, Prop } from 'vue-property-decorator';
import axios from 'axios';
import { IProduct, Product } from '../products/product.model'
import { Carousel, Slide } from 'vue-carousel';
import { IProdSize, ProdSize } from '../sizeproduct/size.model';
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
    qrCode = {};
   
    size = new ProdSize();
    mounted() {
     
        axios.get('api/sizes').then(response => {
            this.sizes = response.data
        }).catch(e => {
            console.log("error");
        })
        this.productSingle();
    }
   Qrcode() {
       const qrText = window.location.origin + '' + window.location.pathname;
       console.log(qrText);
       axios.get('api/singleProduct/qrText=' + qrText).then(response => {
           
            console.log(response);
        }).catch(e => {
                console.log("error");
            })
    }
    productSingle() {
        var self = this;
        this.prodSizes = [];
        this.id = this.$route.params.productId;
        axios.get('api/product/' + this.id).then(response => {
            this.product = response.data["product"];
            this.prodSizes = response.data["sizesProd"];
        }).then(res => {
            for (var i = 0; i < self.prodSizes.length; i++) {
                self.excludeSizes.push(self.prodSizes[i]['size']);
            }
            self.sizes = self.sizes.filter(o => self.excludeSizes.every(
                (elem) => { return elem.sizeId !== o.sizeId }) );
         
        })

            .catch(e => {
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
