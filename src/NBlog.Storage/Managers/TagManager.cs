using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class TagManager : ManagerBase<TagEntity>
    {
        public TagManager(NBlogDbContext context) : base(context)
        {

        }
    }
}
