import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
import { BTabs } from 'bootstrap-vue'
@Component({
    components: {
        BTabs,
    }
})
export default class SizeComponent extends Vue {
    public formData = new FormData();
    public sizes: [{
        floor: number,
        sizeId: string,
        sizeEU: string,
        sizeUS: string,
        sizeUK: string,
        CM: string,
    }] = [{
        floor: 0,
        CM: "",
        sizeEU: "",
        sizeUK: "",
        sizeUS: "",
        sizeId:""
        }];
    update = false
    id = ""
    size = {
        CM: "",
        sizeEU: "",
        sizeUK: "",
        sizeUS: "",
        sizeId: "",
        floor:0
    }
    public sizeEU: string = "";
    public sizeUS: string = "";
    public sizeUK: string = "";
    public cm: string = "";
    show = true;
    public addSize() {
        this.formData.append('sizeEU', this.sizeEU);
        this.formData.append('sizeUS', this.sizeUS);
        this.formData.append('sizeUK', this.sizeUK);
        this.formData.append('cm', this.cm);
        axios.post('api/sizes', this.formData,
            {
                headers: {
                    'Content-Type': 'undefiend'
                }
            }
        ).then(response => {
            this.$toasted.success(response.data + ' succesful!', {
                icon: {
                    name: 'api',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "bottom-center",
                duration: 4000
            });
        }).then(res => {
            this.allSizes();
        }).catch(e => {
            console.log("error");
        })
    }
    allSizes() {
        axios.get('api/sizes').then(response => {
            this.sizes = response.data
        }).catch(e => {
            console.log("error");
        })
    }

    filterSize(val) {
        return this.sizes.filter(s => {
           return s.floor === val;
        })
    }
    editSize(size) {
        this.update = true;
        this.sizeEU = size.sizeEU
        this.sizeUS = size.sizeUS
        this.sizeUK = size.sizeUK
        this.cm = size.CM
        this.size = size
        this.id = size.sizeId
    }
    updateSize() {
        this.size.sizeEU = this.sizeEU
        this.size.sizeUS = this.sizeUS
        this.size.sizeUK = this.sizeUK
        this.size.CM = this.cm
        axios.put('api/sizes/' + this.id, this.size).then(response => {
            this.$toasted.success('Size updated succesful!', {
                icon: {
                    name: 'api',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "bottom-center",
                duration: 4000
            });
            this.update = false
            this.sizeEU = ""
            this.sizeUS = ""
            this.allSizes()
        }).catch(e => {
            console.log("error");
        })
    }
    deleteSize(id) {
        axios.delete('api/sizes/' + id).then(response => {
            this.$toasted.success('Size deleted succesful!', {
                icon: {
                    name: 'api',
                    after: true // this will append the icon to the end of content
                },
                theme: "toasted-primary",
                position: "bottom-center",
                duration: 4000
            });
            this.allSizes()
        }).catch(e => {
            console.log("error");
        })
    }
    onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.sizeEU = ''
        this.sizeUS = ''
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
            this.show = true
        })
    }
    onSubmit(evt) {
        evt.preventDefault()
        this.addSize();
        this.allSizes()
    }
    mounted() {
        this.allSizes();
    }
}
