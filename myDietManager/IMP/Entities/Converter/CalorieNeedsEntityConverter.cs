using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDietManagerAbstract.Abstraction.Entities;
using MyDietManagerAbstract.Abstraction.Entities.Converter;
using MyDietManagerEntities;

namespace myDietManager.IMP.Entities.Converter
{
    public class CalorieNeedsEntityConverter : IConverter<UserCalorieNeed, ICalorieNeeds>
    {
        public ICalorieNeeds Convert(UserCalorieNeed entity)
        {
            throw new NotImplementedException();
        }

        public UserCalorieNeed ConvertBack(ICalorieNeeds pocoObjectToConvert)
        {
            throw new NotImplementedException();
        }
    }
}
