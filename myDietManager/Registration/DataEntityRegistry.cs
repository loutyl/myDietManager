using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.IMP.Entities.Converter;
using myDietManager.IMP.Entities.Repositories;
using MyDietManagerAbstract.Abstraction.Entities;
using MyDietManagerAbstract.Abstraction.Entities.Converter;
using MyDietManagerAbstract.Abstraction.Repositories;
using MyDietManagerAbstract.Abstraction.UnitOfWork;
using MyDietManagerEntities;
using Registry = StructureMap.Configuration.DSL.Registry;

namespace myDietManager.Registration
{
    public class DataEntityRegistry : Registry
    {
        public DataEntityRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<DbContext>().Use<MyDietManagerDBEntities>();
            For<IRepository<User>>().Use<UserRepository>();
            For<IRepository<UsersDietProfile>>().Use<DietProfileRepository>();
            For<IRepository<UserMacronutrient>>().Use<MacronutrientsRepository>();
            For<IRepository<UserCalorieNeed>>().Use<CalorieNeedsRepository>();

            For<IConverter<User, IUser>>().Use<UserEntityConverter>();
            For<IConverter<UsersDietProfile, IDietProfile>>().Use<DietProfileEntityConverter>();
            For<IConverter<UserMacronutrient, IMacronutrients>>().Use<MacronutrientsEntityConverter>();
            For<IConverter<UserCalorieNeed, ICalorieNeeds>>().Use<CalorieNeedsEntityConverter>();
        }
    }
}