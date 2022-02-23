using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class SiteInfoManager : ManagerBase<SiteInfoEntity>
    {
        public SiteInfoManager(NBlogDbContext context) : base(context)
        {

        }
    }
}
