using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class ProfileManager : ManagerBase<ProfileEntity>
    {
        public ProfileManager(NBlogDbContext context) : base(context)
        {

        }
    }
}
