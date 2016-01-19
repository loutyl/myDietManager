using MyDietManagerAbstract.Abstraction.Entities;

namespace MyDietManagerAbstract.Abstraction.DietManagement
{
    public interface IDietManager
    {
        void FinalizeDietProfileCreation(IDietProfile dietProfile);
    }
}
