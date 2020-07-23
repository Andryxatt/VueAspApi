import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class SizeComponent extends Vue {
    public formData = new FormData();
    public sizes: string[] = [];
    // mounted() {
    // }
    public sizeUA: string = "";
    public sizeUSA: string = "";
    show = true;
    public addSize() {
        this.formData.append('sizeUA', this.sizeUA);
        this.formData.append('sizeUSA', this.sizeUSA);
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

    onReset(evt) {
        evt.preventDefault()
        // Reset our form values
        this.sizeUA = ''
        this.sizeUSA = ''
        // Trick to reset/clear native browser form validation state
        this.show = false
        this.$nextTick(() => {
            this.show = true
        })
    }
    onSubmit(evt) {
        evt.preventDefault()
        this.addSize();
    }
    mounted() {
        this.allSizes();
    }
}
