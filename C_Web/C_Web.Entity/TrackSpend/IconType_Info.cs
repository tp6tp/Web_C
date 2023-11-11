using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Web.Entity.TrackSpend
{
    public class IconType_Info
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Icon_TypeId {  get; set; }
        public string TypeName {  get; set; }
        public string TypeColorCode {  get; set; }
    }
}
