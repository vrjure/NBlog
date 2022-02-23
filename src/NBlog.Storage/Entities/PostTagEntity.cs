using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class PostTagEntity
    {
        [Required]
        public long PostId { get; set; }
        [Required]
        public long TagId { get; set; }
    }
}
