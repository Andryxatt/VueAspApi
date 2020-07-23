using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VueAsp.Models
{

    public class Photo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid PhotoId { get; set; }
        public Guid ProductId { get; set; }
        public string Path {
            get
            {
                string mimeType = "image/png";
                string base64 = Convert.ToBase64String(this.ByteImage);
                return string.Format("data:{0};base64,{1}", mimeType, base64);
            }
            set { } }
        public byte[] ByteImage { get; set; }

    }
}
