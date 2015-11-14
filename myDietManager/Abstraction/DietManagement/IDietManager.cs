using System.Collections.Generic;

namespace myDietManager.Abstraction.DietManagement
{
    public interface IDietManager
    {
        IEnumerable<float> GetMacronutrientsRatios(string goal);
    }
}
