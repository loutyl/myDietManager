using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDietManagerAbstract.Entities
{
    public interface IMacronutrients
    {
        int Protein { get; set; }
        int Carbohydrate { get; set; }
        int Fat { get; set; }

        IMacronutrients GetMacronutrientsRatios(IDietProfile dietProfile);
    }
}
