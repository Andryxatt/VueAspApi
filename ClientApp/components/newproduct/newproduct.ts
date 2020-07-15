import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';
import axios from 'axios';
import { IProduct,Product } from '../products/product.model'
import { IBrand } from '../brands/brand.model';
import PhotoComponent from '../photo/photo';


@Component({
    components: {
        PhotoComponent
    }
})
export default class NewProductComponent extends Vue {
    
    @Prop({ required: true, default: () => new Product() }) product!: Product;
    public formData = new FormData();
    files:object[] = [];
    @Prop({ required: true, default: () => [] }) brands!: IBrand[];
    mounted() {
        axios.get('api/brands').then(response => {
            this.brands = response.data
        }).catch(e => {
            console.log("error");
        })
    }
    addProduct() {
        this.formData.append("model", this.product.model);
        this.formData.append("brandId", this.product.brandId.toString());
        this.formData.append("priceBy", this.product.priceBy.toString());
        axios.post('api/product', 
            this.formData
        ).then(response => {
            this.$toasted.success(response.data + ' succesful!', {
                icon: {
                    name: 'watch',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "top-right",
                duration: 4000
            });
            this.$router.go(-1);
        }).catch(e => {
            console.log("error");
        })
    }
    returnUrl(obj: object):string {
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
