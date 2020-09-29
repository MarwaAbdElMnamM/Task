using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class ClientPhoneNumber
    {
        public int ID { get; set; }
        

        public int PhoneNumber { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
      


    }
}