using System.Collections.Generic;
using MyDietManagerAbstract.Abstraction.DietManagement;
using MyDietManagerAbstract.Abstraction.Entities;
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

        public void FinalizeDietProfileCreation(IDietProfile dietProfile)
        {
            dietProfile.CalorieNeeds = this._dietCalculator.CalculateCalorieNeeds(dietProfile);
            dietProfile.Macronutrients = this._dietCalculator.CalculateMacroRepartition(dietProfile);
        }
    }
}
