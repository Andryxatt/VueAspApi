import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import axios from 'axios'
@Component
export default class CategoriesComponent extends Vue {
    mounted() {
        //axios.get('api/brands').then(response => {
        //    this.brands = response.data
        //}).catch(e => {
        //    console.log("error");
        //})
    }
    category = {
        nameCategory: "Name",
        description: "Description"
    }
    categories = [];

    Categories() {
         axios.get('api/categories').then(response => {
             this.categories = response.data
        }).catch(e => {
            console.log("error");
        })
    }
    addCategory() {
        axios.post('api/categories', this.category).then(response => {
            this.$toasted.success(response.data + ' succesful!', {
                icon: {
                    name: 'watch',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "top-right",
                duration: 4000
            });
        }).catch(e => {
            console.log("error")
        })
    }
}