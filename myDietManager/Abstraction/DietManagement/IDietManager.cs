using System.Collections.Generic;
using myDietManager.Abstraction.Entities;

namespace myDietManager.Abstraction.DietManagement
{
    public interface IDietManager
    {
        void FinalizeDietProfileCreation(IDietProfile dietProfile);
    }
}
