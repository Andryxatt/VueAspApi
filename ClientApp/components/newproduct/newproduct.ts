import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';
import axios from 'axios';
import { IProduct, Product } from '../../data/models/product.model'
import { BFormFile } from 'bootstrap-vue'
import { IBrand } from '../../data/models/brand.model';
import PhotoComponent from '../photo/photo';
import { ValidationProvider, extend, ValidationObserver } from 'vee-validate';
import { required } from 'vee-validate/dist/rules';
extend('required', {
    ...required,
    message: 'Заповніть поле'
})
extend('secret', {
    validate: value => value > 0,
    message: 'Ціна не може бути 0'
})
extend('priceUSD', {
    validate: value => value > 5,
    message: 'Ціна не може бути нижче 5'
});
extend('priceUAH', {
    validate: value => value > 50,
    message: 'Ціна не може бути нижча 50'
});
@Component({
    components: {
        PhotoComponent,
        ValidationProvider,
        ValidationObserver,
        BFormFile
    }
})

export default class NewProductComponent extends Vue {
    errors: string[] = []
    uah = "&#8372"
    isDiscount = true
    @Prop({ required: true, default: () => new Product() }) product!: Product;
    public formData = new FormData();
    files: object[] = [];
    @Prop({ required: true, default: () => [] }) brands!: IBrand[];
    mounted() {
        axios.get('api/brands').then(response => {
            this.brands = response.data
        }).catch(e => {
            console.log("error");
        })
    }

    checkForm() {
        this.formData.append("model", this.product.model);
        this.formData.append("brandId", this.product.brandId.toString());
        this.formData.append("priceBy", this.product.priceBy.toString());
        this.formData.append("countBoxes", this.product.countBoxes.toString());
        this.formData.append("countPairsInBox", this.product.countPairsInBox.toString());
        this.formData.append("sizesInBox", this.product.sizesInBox.toString());
        this.formData.append("priceSalleUS", this.product.priceSalleUS.toString());
        this.formData.append("priceSalleUAH", this.product.priceSalleUAH.toString());
        if (this.product.isDiscount) {
            this.formData.append("isDiscount", this.product.isDiscount.toString());
            this.formData.append("discountUAH", this.product.discountUAH.toString());
            this.formData.append("discountUS", this.product.discountUS.toString());
        }
        this.formData.append("isDiscount", "false");
        this.formData.append("discountUAH", "0");
        this.formData.append("discountUS", "0");
        axios.post('api/product', this.formData)
            .then(response => {
                this.$toasted.success(response.data + ' succesful!', {
                    icon: {
                        name: 'watch', after: true // this will append the icon to the end of content
                    },
                    theme: "toasted-primary",
                    position: "top-right",
                    duration: 4000
                });
                //this.$router.go(-1);
            }).catch(e => {
                console.log("error");
            })
    }
    check(e) {
        this.isDiscount = !e
    }
    resetForm() {

    }
    returnUrl(obj: object): string {
        var url = URL.createObjectURL(obj);
        return url;
    }
    slicePhoto(index: number): void {
        this.files.splice(index, 1);
        this.handleFileUpload(this.files);
    }
    handleFileUpload(fileList: any) {
        this.files = [];
        this.formData.delete("files");
        for (var i = 0; i < fileList.length; i++) {
            this.formData.append("files", fileList[i], fileList[i].name);
            this.files[i] = fileList[i];
        }
        console.log(this.files);
    }
}
