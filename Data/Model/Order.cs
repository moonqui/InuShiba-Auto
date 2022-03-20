using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Data.Model
{
    /// <summary>
    /// Ентити, което съхранява информация за поръчките.
    /// </summary>
    /// <list type="table">
    /// <item>
    /// <term>OrderId</term>
    /// <description>
    /// Съхранява уникалния идентификационен номер на поръчката.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Clients</term>
    /// <description>
    /// Връзка с таблица <c>Client</c>.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Cars</term>
    /// <description>
    /// Връзка с таблица <c>Car</c>.
    /// </description>
    /// </item>
    /// </list>
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public Client Client { get; set; }
        public List<Car> Cars { get; set; }
    }
}
