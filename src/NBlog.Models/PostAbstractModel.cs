using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog
{
    public class PostAbstractModel : BaseModel
    {
        public string? Title { get; set; }
        public long CategoryId { get; set; }
        public string? Abstract { get; set; }
        public string[]? Tags { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
