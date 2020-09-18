import Vue from 'vue'
import { Component } from 'vue-property-decorator'
import { BNavbar } from 'bootstrap-vue'
import DefaultLayout from '../../layouts/default-layout'
import AdminLayout from '../../layouts/admin-layout'
@Component({
    components: {
        BNavbar,
        MenuComponent: require('../navmenu/navmenu.vue.html'),
        DefaultLayout,
        AdminLayout
     
    },
   
})
export default class AppComponent extends Vue {
}
