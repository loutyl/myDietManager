using System.Collections.Generic;

namespace myDietManager.Abstraction.Entities
{
    public interface IMacronutrients
    {
        int Protein { get; set; }
        int Carbohydrate { get; set; }
        int Fat { get; set; }

        IEnumerable<float> GetMacronutrientsRatios(string goal);
    }
}
