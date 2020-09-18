import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import axios from 'axios'
import { IBrand } from '../../data/models/brand.model'

@Component
export default class BrandComponent extends Vue {
    brands: IBrand[] = []
    show = true
    update = false
    brand: IBrand = {
        description: 'description',
        nameBrand: 'name brand'
    };
    rows = 100
    perPage = 8
    currentPage = 1
    hasNext = false
    hasPrev = false
    nextPage() {
        if (this.hasNext)
            this.currentPage++

        this.allBrands();
    }
    prevPage() {
        if (this.hasPrev)
            this.currentPage--

        this.allBrands()
    }

    mounted() {
        this.allBrands()
    }
    allBrands() {
        axios.get('api/brands?pageNumber=' + this.currentPage + '&pageSize=' + this.perPage).then(response => {
            this.brands = response.data
            this.rows = JSON.parse(response.headers['x-pagination'])['TotalPages']
            this.currentPage = JSON.parse(response.headers['x-pagination'])['CurrentPage']
            this.hasNext = JSON.parse(response.headers['x-pagination'])['HasNext']
            this.hasPrev = JSON.parse(response.headers['x-pagination'])['HasPrevious']
        }).catch(e => {
            console.log("error")
        });
    }
    onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.brand.nameBrand = ''
        this.brand.description = ''
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.update = false
        this.$nextTick(() => {
            this.show = true
        })
    }
    onSubmit(evt) {
        evt.preventDefault()
        axios.post('api/brands', this.brand).then(response => {
            this.$toasted.success('Brand added succesful!', {
                icon: {
                    name: 'api',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "bottom-center",
                duration: 4000
            });
        }).then(res => {
            this.allBrands()
        }).catch(e => {
            this.$toasted.error('Error 500!', {
                icon: {
                    name: 'error',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "bottom-center",
                duration: 4000
            });
        })
    }
    editBrand(id) {
        this.update = true
        this.brand.description = this.brands.filter(x => x.brandId === id)[0].description
        this.brand.brandId = this.brands.filter(x => x.brandId === id)[0].brandId
        this.brand.nameBrand = this.brands.filter(x => x.brandId === id)[0].nameBrand
    }
    saveUpdate() {
        axios.put('api/brands/' + this.brand.brandId, this.brand).then(response => {
            this.update = false
            this.brands = response.data
            this.$toasted.success('Brand updated succesful!', {
                icon: {
                    name: 'api',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "bottom-center",
                duration: 4000
            });
        }).catch(e => {
            console.log("error")
        })
    }
}
