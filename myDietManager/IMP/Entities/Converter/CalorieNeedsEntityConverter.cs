using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.Abstraction.Entities;

namespace myDietManager.IMP.Entities.Converter
{
    public class CalorieNeedsEntityConverter : IConverter<UserCalorieNeeds, ICalorieNeeds>
    {
        public ICalorieNeeds Convert(UserCalorieNeeds entity)
        {
            throw new NotImplementedException();
        }

        public UserCalorieNeeds ConvertBack(ICalorieNeeds pocoObjectToConvert)
        {
            throw new NotImplementedException();
        }
    }
}
