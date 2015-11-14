using System.Collections.Generic;
using myDietManager.Abstraction.DietManagement;

namespace myDietManager.IMP.DietManagement
{
    public class DietManager : IDietManager
    {
        public IEnumerable<float> GetMacronutrientsRatios(string goal)
        {
            return goal == "Lose" ? new List<float>{ 0.4f, 0.4f, 0.2f } : new List<float>{ 0.5f, 0.3f, 0.2f };
        }
    }
}
