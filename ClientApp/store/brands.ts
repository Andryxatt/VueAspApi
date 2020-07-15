import { State } from '../types'
import { GetterTree } from 'vuex'
 
export const state:State = {
    brands: [
        {
            nameBrand: "Ipanema",
            description:"Some interesting info about brand"
        }
    ]
}

export const getters: GetterTree<State, any> = {
    brands: state=>state.brands
}