import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class PhotoComponent extends Vue {
  
    drawer = null
    @Prop({ required: true, default: () => new String }) source!: String;
    mounted() {
    }
    
  
}
