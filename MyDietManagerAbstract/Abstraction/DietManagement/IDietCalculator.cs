using MyDietManagerAbstract.Abstraction.Entities;

namespace MyDietManagerAbstract.Abstraction.DietManagement
{
    public interface IDietCalculator
    {
        ICalorieNeeds CalculateCalorieNeeds(IDietProfile dietProfile);
        IMacronutrients CalculateMacroRepartition(IDietProfile dietProfile);
    }
}
