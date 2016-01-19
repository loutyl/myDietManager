using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.IMP.POCO;
using MyDietManagerAbstract.Abstraction.Entities;
using Registry = StructureMap.Configuration.DSL.Registry;

namespace myDietManager.Registration
{
    public class POCOModelRegistry : Registry
    {
        public POCOModelRegistry()
        {
            For<IUser>().Use<POCOUser>();
            For<IDietProfile>().Use<POCODietProfile>();
            For<IMacronutrients>().Use<POCOMacronutrients>();
            For<ICalorieNeeds>().Use<POCOCalorieNeeds>();
        }
        
    }
}
