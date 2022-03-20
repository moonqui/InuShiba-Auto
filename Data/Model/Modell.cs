using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Modell
    {
        public int ModellId { get; set; }
        public string ModellName { get; set; }
        public List<Car> Cars { get; set; }
    }
}