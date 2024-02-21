using System;
using System.Collections.Generic;

namespace MicroserviceProduct.Models
{
    public partial class Client
    {
        public Client()
        {
            Accouts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Account> Accouts { get; set; }
    }
}
