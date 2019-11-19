using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class ClientAddress
    {
        [Key]
        public int ClientAddressId { get; set; }

        public int Cid { get; set; }
        public string Address { get; set; }
        

        public Clients ccid { get; set; }

    }
}