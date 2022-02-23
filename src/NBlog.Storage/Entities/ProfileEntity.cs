using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class ProfileEntity : EntityBase
    {
        [MaxLength(255)]
        public string? Name { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        [MaxLength(1000)]
        public string? Avatar { get; set; }
    }
}
