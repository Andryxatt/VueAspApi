import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import axios from 'axios';
@Component
export default class PhotoComponent extends Vue {
    public productId = '';
    
    @Prop({ required: true, default: () => new FormData() }) formData!: FormData;
    mounted() {
    }
    
   public addPhotos() {
        axios.post('api/photo', this.formData,
            {
                headers: {
                    'Content-Type': 'undefiend'
                }
            }
       ).then(response => {
            console.log("succes");
            }).catch(e => {
                console.log(e);
            console.log("error");
        })
    }
    deletePhoto(id: string): void {
        axios.delete('api/photos/' + id).then(response => {
            console.log("succes");
        }).catch(e => {
            console.log("error");
        })
    }
    handleFileUpload(fileList: any) {
        for (var i = 0; i < fileList.length; i++) {
           
            this.formData.append("files", fileList[i], fileList[i].name);
        }
    }
}
