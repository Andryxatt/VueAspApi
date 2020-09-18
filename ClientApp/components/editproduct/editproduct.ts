import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';
import axios from 'axios';
import { IProduct,Product } from '../../data/models/product.model'
import { IBrand } from '../../data/models/brand.model';
import  PhotoComponent  from '../photo/photo';


@Component({
    components: {
        PhotoComponent
    }
})
export default class EditProductComponent extends Vue {
    
    @Prop({ required: true, default: () => new Product() }) product!: Product;
    public formData = new FormData();
    files:object[] = [];
    @Prop({ required: true, default: () => [] }) brands!: IBrand[];
   
    editProduct(prod: Product): void {
        this.product = prod;
       
    }
    saveUpdate() {
        axios.put('api/product', this.product).then(response => {
            console.log("succes");
            this.$emit("AllProducts");
        }).catch(e => {
            console.log("error");
        })
       
    }
    deletePhoto(id: string) {
        axios.delete('api/photo/' + id).then(response => {
            console.log("succes");
        }).catch(e => {
            console.log("error");
        })
    }
    returnUrl(obj: object): string {
       
        var url = "data:image/png;base64," + obj;
        return url;
    }
    slicePhoto(index:number): void {
        this.product.photos.slice(index, 1);
        //this.handleFileUpload(this.files);
    }
    handleFileUpload(fileList: any) {
        this.files = [];
        this.formData.delete("files");
        for (var i = 0; i < fileList.length; i++) {
            this.formData.append("files", fileList[i], fileList[i].name);
            this.files[i] = fileList[i];
        }
     
    }
}
