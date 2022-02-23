using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog
{
    public class Pagination
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class Pagination<T> : Pagination
    {
        public int Total { get; set; }
        public ICollection<T>? Data { get; set; }
    }
}
