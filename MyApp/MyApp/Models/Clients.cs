using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyApp.Models
{
    public class Clients
    {
       

        [Key]
        public int Cid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public ICollection<ClientAddress> clientAdd { get; set; }
    }
}