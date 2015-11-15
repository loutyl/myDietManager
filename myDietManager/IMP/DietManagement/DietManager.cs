using System.Collections.Generic;
using myDietManager.Abstraction.DietManagement;
using myDietManager.Abstraction.Entities;
using StructureMap;

namespace myDietManager.IMP.DietManagement
{
    public class DietManager : IDietManager
    {
        private IContainer _container;
        private readonly IDietCalculator _dietCalculator;

        public DietManager(IContainer container)
        {
            this._container = container;
            this._dietCalculator = this._container.GetInstance<IDietCalculator>();
        }

        public IEnumerable<float> GetMacronutrientsRatios(string goal)
        {
            return goal == "Lose" ? new List<float>{ 0.4f, 0.4f, 0.2f } : new List<float>{ 0.5f, 0.3f, 0.2f };
        }

        public void FinalizeDietProfileCreation(IDietProfile dietProfile)
        {
            dietProfile.CalorieNeeds = this._dietCalculator.CalculateCalorieNeeds(dietProfile);
            dietProfile.Macronutrients = this._dietCalculator.CalculateMacroRepartition(dietProfile);
        }
    }
}
