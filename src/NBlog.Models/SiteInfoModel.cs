﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog
{
    public class SiteInfoModel : BaseModel
    {
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
    }
}
