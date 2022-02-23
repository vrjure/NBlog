using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
