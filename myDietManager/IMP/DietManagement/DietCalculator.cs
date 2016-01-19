using System;
using System.Linq;
using MyDietManagerAbstract.Abstraction.DietManagement;
using MyDietManagerAbstract.Abstraction.Entities;
using StructureMap;

namespace myDietManager.IMP.DietManagement
{
    public class DietCalculator : IDietCalculator
    {
        private readonly IContainer _container;

        public DietCalculator(IContainer container)
        {
            this._container = container;
        }

        public ICalorieNeeds CalculateCalorieNeeds(IDietProfile dietProfile)
        {
            var calorieNeeds = this._container.GetInstance<ICalorieNeeds>();
            calorieNeeds.MaintenanceCalories = ((int) dietProfile.Weight*dietProfile.ActivityLevel);
            calorieNeeds.DailyCalories = dietProfile.Goal == "Gain"
                ? ( calorieNeeds.MaintenanceCalories + 250 )
                : ( calorieNeeds.MaintenanceCalories - 500 );

            return calorieNeeds;
        }

        public IMacronutrients CalculateMacroRepartition(IDietProfile dietProfile)
        {
            var macronutrients = this._container.GetInstance<IMacronutrients>();
            var macrosRatios = macronutrients.GetMacronutrientsRatios(dietProfile.Goal);

            var nutrients = (from ratio in macrosRatios 
                                let calorie = Math.Abs(dietProfile.CalorieNeeds.DailyCalories*ratio) 
                                let divider = ratio.Equals(0.2f) ? 9 : 4 
                                select Math.Abs((calorie/divider)) 
                                into weight 
                                select (int) weight).ToList();
            
            macronutrients.Carbohydrate = nutrients[0];
            macronutrients.Protein = nutrients[1];
            macronutrients.Fat = nutrients[2];

            return macronutrients;
        }
    }
}
