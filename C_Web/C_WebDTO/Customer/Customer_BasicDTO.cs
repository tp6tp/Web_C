using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_WebDTO.Customer
{
    public class Customer_BasicDTO
    {
       public string industrialName {  get; set; }
        public string attributeName { get; set; }

        public long UserId {  get; set; }
        public long ID { get; set; }


        public string ContactType {  get; set; }
        public string ContactArea { get; set; }

    }
}
