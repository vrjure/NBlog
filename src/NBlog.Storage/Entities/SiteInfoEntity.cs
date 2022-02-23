using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class SiteInfoEntity : EntityBase
    {
        [MaxLength(255)]
        public string? Title { get; set; }
        [MaxLength(255)]
        public string? SubTitle { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        [MaxLength(255)]
        public string? Keywords { get; set; }
    }
}
