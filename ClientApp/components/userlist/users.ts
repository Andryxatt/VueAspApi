import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class UsersComponent extends Vue {
    public users: [{}] = [{}]
    mounted() {
        this.allUsers()
    }
    public userRoles = [{}]
    public roles = [{}]
    @Prop({ required: true, default: () => new FormData() }) formData!: FormData;
    allUsers() {
        axios.get('users/').then(response => {
            this.users = response.data
        }).catch(e => {
            console.log("error")
        })
    }
    showUserRoles(id) {
        axios.get('users/' + id + "/" + this.roles).then(response => {
            console.log(response.data)
            this.roles = response.data.allRoles
            this.userRoles = response.data.userRoles
        }).catch(e => {
            console.log("error")
        })
    }
   
}
