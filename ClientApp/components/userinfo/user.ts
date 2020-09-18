import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class UserComponent extends Vue {
    public user = {};
    id = ""
    mounted() {
        this.id = this.$route.params.id
        this.userInfo(this.$route.params.id)
    }
    public userRoles =[]
    public roles = [{}]
    @Prop({ required: true, default: () => new FormData() }) formData!: FormData;
    //allUsers() {
    //    axios.get('users/').then(response => {
    //        this.users = response.data
    //    }).catch(e => {
    //        console.log("error")
    //    })
    //}
    saveRoles() {
        for (var i = 0; i < this.userRoles.length; i++) {
            this.formData.append("roles", this.userRoles[i])
        }
        this.formData.append("userId", this.id)
        axios.post('user-roles-add/', this.formData).then(response => {
            console.log(response.data)
          
        }).catch(e => {
            console.log("error")
        })
    }
    userInfo(id) {
        axios.get('users/' + id + "/" + this.roles).then(response => {
            console.log(response.data)
            this.roles = response.data.allRoles
            this.userRoles = response.data.userRoles
        }).catch(e => {
            console.log("error")
        })
    }
   
}
