using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class TagEntity : EntityBase
    {
        [Required]
        public string? Name { get; set; }
    }
}
