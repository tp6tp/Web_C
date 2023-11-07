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
        #region for SYSList
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
        #endregion

        #region for Customer
        public string STime { get; set; }
        public string ETime { get; set; }
        public string Company { get; set; }
        public string Unicode { get; set; }
        public string Type { get; set; }
        #endregion
    }
}
