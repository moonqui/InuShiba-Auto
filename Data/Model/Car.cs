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
    /// <term>CarId</term>
    /// <description>
    /// Съхранява уникалния идентификационен номер на колата.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Brand</term>
    /// <description>
    /// Връзка с таблица <c>Brand</c>.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Modell</term>
    /// <description>
    /// Връзка с таблица <c>Modell</c>.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Price</term>
    /// <description>
    /// Съхранява единичната цена на колата.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Fuel</term>
    /// <description>
    /// Съхранява информация за горивото, което използва на колата.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Colour</term>
    /// <description>
    /// Съхранява информациа за цвета на колата.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Order</term>
    /// <description>
    /// Връзка с таблица <c>Order</c>.
    /// </description>
    /// </item>
    /// </list>
    public class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ModellId { get; set; }
        public Brand Brands { get; set; }
        public Modell Modells { get; set; }
        public double Price { get; set; }
        public string Fuel { get; set; }
        public string Colour { get; set; }
        public Order Order { get; set; }
    }
}
