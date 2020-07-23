import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import axios from 'axios'
import { IBrand } from '../brands/brand.model'

@Component
export default class BrandComponent extends Vue {
    brands: IBrand[] = [];
    show = true;
    brand: IBrand = {
        description: 'description',
        nameBrand:'name brand'
    }; 
    created() {
      this.allBrands();
    }
    allBrands() {
        axios.get('api/brands').then(response => {
            this.brands = response.data
        }).catch(e => {
            console.log("error");
        })
    }
    onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.brand.nameBrand = ''
        this.brand.description = ''
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
            this.show = true
        })
    }
    onSubmit(evt) {
        evt.preventDefault()
     
        axios.post('api/brands', this.brand).then(response => {
            this.$toasted.success(response.data + ' succesful!', {
                icon: {
                    name: 'api',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "bottom-center",
                duration: 4000
            });
        }).then(res => {
            this.allBrands();
        }).catch(e => {
            console.log("error")
        })
    }
   
}
