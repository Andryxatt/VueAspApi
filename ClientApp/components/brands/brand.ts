import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import axios from 'axios'
import { IBrand } from '../brands/brand.model'
import {Getter} from 'vuex-class'
@Component
export default class BrandComponent extends Vue {
    @Getter brands: IBrand[] | undefined;
    brand: IBrand = {
        description: 'description',
        nameBrand:'name brand'
    }; 
    mounted() {
        //axios.get('api/brands').then(response => {
        //    this.brands = response.data
        //}).catch(e => {
        //    console.log("error");
        //})
    }
    
    addBrand() {
        axios.post('api/brands', this.brand).then(response => {
            console.log("succes")
        }).catch(e => {
            console.log("error")
        })
    }
}
