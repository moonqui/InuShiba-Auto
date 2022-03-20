using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Data.Model
{
    /// <summary>
    /// Ентити, което съхранява информация за клиентите.
    /// </summary>
    /// <list type="table">
    /// <item>
    /// <term>ClientId</term>
    /// <description>
    /// Съхранява уникалния идентификационен номер на клиента.
    /// </description>
    /// </item>
    /// <item>
    /// <term>ClientName</term>
    /// <description>
    /// Съхранява името на клиента.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Phone</term>
    /// <description>
    /// Съхранява телефонния номер на клиента.
    /// </description>
    /// </item>
    /// </list>
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }
}
