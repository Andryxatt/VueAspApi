import Vue from 'vue'
import Vuex from 'vuex'
import { state, getters } from './brands'
import axios from 'axios'
Vue.use(Vuex)

export const store = new Vuex.Store({
    state,
    getters,

})