using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class PostTagManager : ManagerBase<PostTagEntity>
    {
        public PostTagManager(NBlogDbContext context) : base(context)
        {

        }
    }
}
