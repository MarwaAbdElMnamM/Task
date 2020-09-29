using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"[a-zA-z]+", ErrorMessage = "Name must allow char only and no space contain")]
        public string name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }
        public virtual ICollection<ClientPhoneNumber> ClientPhoneNumbers { get; set; }

    }
}