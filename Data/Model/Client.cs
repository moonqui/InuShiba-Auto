using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
