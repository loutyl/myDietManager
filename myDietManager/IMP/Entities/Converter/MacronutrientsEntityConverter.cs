using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.Abstraction.Entities;

namespace myDietManager.IMP.Entities.Converter
{
    public class MacronutrientsEntityConverter : IConverter<UserMacronutrients, IMacronutrients>
    {
        public IMacronutrients Convert(UserMacronutrients entity)
        {
            throw new NotImplementedException();
        }

        public UserMacronutrients ConvertBack(IMacronutrients pocoObjectToConvert)
        {
            throw new NotImplementedException();
        }
    }
}
