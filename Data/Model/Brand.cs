using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Data.Model
{
    /// <summary>
    /// Ентити, което съхранява информация за марките на колите.
    /// </summary>
    /// <list type="table">
    /// <item>
    /// <term>brandId</term>
    /// <description>
    /// Съхранява уникалния идентификационен номер на марката.
    /// </description>
    /// </item>
    /// <item>
    /// <term>BrandName</term>
    /// <description>
    /// Съхранява името на марката.
    /// </description>
    /// </item>
    /// </list>
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
