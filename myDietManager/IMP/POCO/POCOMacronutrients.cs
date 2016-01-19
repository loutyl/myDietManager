using System.Collections.Generic;
using MyDietManagerAbstract.Abstraction.Entities;

namespace myDietManager.IMP.POCO
{
    public class POCOMacronutrients : IMacronutrients
    {
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }

        public IEnumerable<float> GetMacronutrientsRatios(string goal)
        {
            return goal == "Lose" ? new List<float> { 0.4f, 0.4f, 0.2f } : new List<float> { 0.5f, 0.3f, 0.2f };
        }
    }
}
