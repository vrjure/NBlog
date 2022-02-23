using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBlog.Storage
{
    public class PostEntity : EntityBase
    {
        [MaxLength(255)]
        public string? Title { get; set; }
        public long CategoryId { get; set; }
        [MaxLength(255)]
        public string? Abstract { get; set; }
        public string? Content { get; set; }
        public PostType Type { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdateTime { get; set; }
    }
}
