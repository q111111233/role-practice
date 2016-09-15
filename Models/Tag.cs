using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; }
        public virtual Image Image { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
