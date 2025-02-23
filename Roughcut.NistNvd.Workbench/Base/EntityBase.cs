using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roughcut.NistNvd.Workbench.Base
{
    public class EntityBase
    {
        [Key]
        public Guid ModelKeyId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ModelRowId { get; set; }

    }
}
