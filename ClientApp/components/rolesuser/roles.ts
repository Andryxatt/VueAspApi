import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class RolesComponent extends Vue {
    public roles: [{}] = [{}];
    mounted() {
        this.allRolls();
    }
    name: string = "";
    @Prop({ required: true, default: () => new FormData() }) formData!: FormData;
    allRolls() {
        axios.get('roles/').then(response => {
            this.roles = response.data
        }).catch(e => {
            console.log("error");
        })
    }
    addRole() {
        this.formData.append("name", this.name)
        axios.post('roles/create/'+this.name).then(response => {
            this.allRolls();
        }).catch(e => {
            console.log("error");
        })
    }
    DeleteRole(id) {
        axios.post('roles/delete/'+id).then(response => {
           
        }).catch(e => {
            console.log("error");
        })
    }
}
