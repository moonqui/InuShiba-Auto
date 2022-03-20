using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Data.Model
{
    /// <summary>
    /// Ентити, което съхранява информация за моделите на колите.
    /// </summary>
    /// <list type="table">
    /// <item>
    /// <term>ModellId</term>
    /// <description>
    /// Съхранява уникалния идентификационен номер на модела.
    /// </description>
    /// </item>
    /// <item>
    /// <term>ModellName</term>
    /// <description>
    /// Съхранява името на модела.
    /// </description>
    /// </item>
    /// </list>
    public class Modell
    {
        public int ModellId { get; set; }
        public string ModellName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
