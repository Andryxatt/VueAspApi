import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import axios from 'axios'
import { ISubCategory } from '../../data/models/subcategory.model'
@Component
export default class SubCategoryComponent extends Vue {
    catId = ""
   public subCategory: ISubCategory = {
        nameSub: '',
        description: '',
       categoryId: this.catId

    }
    mounted() {
        this.catId = this.$route.params.id
        this.SubCategories(this.catId)
    }
   
    formData = new FormData();
    //public category:ICategory = {
    //    nameCategory: "",
    //    description: ""
    //}
    subCategories = [];
    SubCategories(id) {
        console.log(id);
        axios.get('api/SubCategory/'+ id).then(response => {
            this.subCategories = response.data
        }).catch(e => {
            console.log("error");
        })
    }
    onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.subCategory.nameSub = ''
        this.subCategory.description = ''
        this.subCategory.categoryId = this.catId
        // Trick to reset/clear native browser form validation state
    }
    onSubmit(evt) {
        evt.preventDefault();
        this.subCategory.categoryId = this.catId;
        axios.post('api/SubCategory', this.subCategory as ISubCategory).then(response => {
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
            this.SubCategories(this.catId);
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