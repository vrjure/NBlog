using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class PostManager : ManagerBase<PostEntity>
    {
        public PostManager(NBlogDbContext context) : base(context)
        {

        }
    }
}
