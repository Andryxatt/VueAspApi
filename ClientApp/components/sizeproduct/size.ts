import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class SizeComponent extends Vue {
    public formData = new FormData();
    public sizes: string[] = [];
   // mounted() {
   // }
    public sizeUA: string = "";
    public sizeUSA: string = "";
    public addSize() {
        this.formData.append('sizeUA', this.sizeUA);
        this.formData.append('sizeUSA', this.sizeUSA);
        
        axios.post('api/sizes', this.formData,
            {
                headers: {
                    'Content-Type': 'undefiend'
                }
            }
       ).then(response => {
            console.log("succes");
            }).catch(e => {
                console.log(e);
            console.log("error");
        })
    }
    mounted() {
        axios.get('api/sizes').then(response => {
            this.sizes = response.data
        }).catch(e => {
            console.log("error");
        })
    }
   
}
