import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import { BootstrapVue } from 'bootstrap-vue/dist/bootstrap-vue.esm';
import VueRouter from 'vue-router'
import Toasted from 'vue-toasted'
import store from './store/index'
import VueMeta from 'vue-meta'

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css'; 
Vue.use(Toasted);
Vue.use(BootstrapVue);
Vue.use(VueRouter);
//Vue.config.productionTip = false;
Vue.config.devtools = true;

Vue.use(VueMeta, {
    // optional pluginOptions
    refreshOnceOnNavigation: true
})
const routes = [
    { path: '/products', component: require('./components/products/products.vue.html') },
    { path: '/brands', component: require('./components/brands/brands.vue.html') },
    { path: '/categories', component: require('./components/categories/categories.vue.html') },
    { path: '/photos', component: require('./components/photo/photos.vue.html') },
    { path: '/newproduct', component: require('./components/newproduct/newprod.vue.html') },
    { path: '/roles-user', component: require('./components/rolesuser/roles.vue.html') },
    { path: '/editproduct', component: require('./components/editproduct/editprod.vue.html') },
    { path: '/sizeproduct', component: require('./components/sizeproduct/sizes.vue.html') },
    { path: '/subcategory/:id', component: require('./components/subcategory/subcategory.vue.html') },
    { path: '/users-list', component: require('./components/userlist/users.vue.html') },
    { path: '/user/:id', component: require('./components/userinfo/user.vue.html') },
    { path: '/singleproduct/:productId', name: 'single', component: require('./components/singleproducts/single-product-list.vue.html') },
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    store,
    render: h => h(require('./components/app/app.vue.html'))
});
