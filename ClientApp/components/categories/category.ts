import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import axios from 'axios'
import { ICategory } from '../../data/models/category.model'
@Component
export default class CategoriesComponent extends Vue {
    mounted() {
        this.Categories();
    }
    formData = new FormData();
    public category:ICategory = {
        nameCategory: "",
        description: ""
    }
    categories = [];

    Categories() {
         axios.get('api/categories').then(response => {
             this.categories = response.data
        }).catch(e => {
            console.log("error");
        })
    }


    onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.category.nameCategory = ''
        this.category.description = ''
        // Trick to reset/clear native browser form validation state
    }
    onSubmit(evt) {
        evt.preventDefault();
        axios.post('api/Categories', this.category as ICategory).then(response => {
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
            this.Categories();
        }).catch(e => {
            this.$toasted.error(e + ' succesful!', {
                icon: {
                    name: 'error',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-error",
                position: "bottom-center",
                duration: 4000
            });
        })
    }
}