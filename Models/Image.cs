using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicAuthentication.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string Tag { get; set; }
        public int Like { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}