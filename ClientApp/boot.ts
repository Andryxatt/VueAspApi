import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import BootstrapVue from 'bootstrap-vue/dist/bootstrap-vue.esm';
import VueRouter from 'vue-router';
import Toasted from 'vue-toasted';
import {store} from './store'


Vue.use(Toasted);
Vue.use(BootstrapVue);
Vue.use(VueRouter);
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css'; 

Vue.config.productionTip = false;
Vue.config.devtools = true;

const routes = [
    { path: '/', component: require('./components/products/products.vue.html') },
    { path: '/brands', component: require('./components/brands/brands.vue.html') },
    { path: '/photos', component: require('./components/photo/photos.vue.html') },
    { path: '/newproduct', component: require('./components/newproduct/newprod.vue.html') },
    { path: '/editproduct', component: require('./components/editproduct/editprod.vue.html') },
    { path: '/sizeproduct', component: require('./components/sizeproduct/sizes.vue.html') },
    { path: '/singleproduct/:productId', name: 'single', component: require('./components/singleproducts/single-product-list.vue.html') }
];

new Vue({
    el: '#app-root',
    store,
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
