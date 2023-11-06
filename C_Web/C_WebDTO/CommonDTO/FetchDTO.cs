using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_WebDTO.CommonDTO
{
    public class FetchDTO
    {
        public object[] data { get; set; }
        public object[] order { get; set; }
        public string PKId { get; set; }
        public bool OnOff { get; set; }
        public long SYSListId { get; set; }
        public string FAID { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int Orders { get; set; }
        public long MUser { get; set; }
        public string MTime { get; set; }
    }
}
