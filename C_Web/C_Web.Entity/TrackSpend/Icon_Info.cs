using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.TrackSpend
{
    public class Icon_Info
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IconId { get; set; }
        public string IconCode { get; set; }
        public string FirstStr { get; set; }
    }
}
