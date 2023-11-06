using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_WebDTO.CommonDTO
{
    public class DataTableDTO
    {
        public List<DataTableDTO_content> data { get; set; }
    }
    public class DataTableDTO_content
    {
        public long PKId { get; set; }
        public int intId { get; set; }
        public int  orderint { get; set; }
        public bool booldata {  get; set; }
        public string Text1 {  get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public string Text6 { get; set; }
        public string Text7 { get; set; }
        public string Text8 { get; set; }
        public string Text9 { get; set; }
        public string Text10 { get; set; }
        public string Text11 { get; set; }
        public string Text12 { get; set; }
        public string Text13 { get; set; }
        public string Text14 { get; set; }
        public string Text15 { get; set; }
    }
   
}
