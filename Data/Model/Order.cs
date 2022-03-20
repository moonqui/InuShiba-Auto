﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public Client Client { get; set; }
        public List<Car> Cars { get; set; }
    }
}
