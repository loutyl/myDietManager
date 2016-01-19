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
    public class MacronutrientsEntityConverter : IConverter<UserMacronutrient, IMacronutrients>
    {
        public IMacronutrients Convert(UserMacronutrient entity)
        {
            throw new NotImplementedException();
        }

        public UserMacronutrient ConvertBack(IMacronutrients pocoObjectToConvert)
        {
            throw new NotImplementedException();
        }
    }
}
