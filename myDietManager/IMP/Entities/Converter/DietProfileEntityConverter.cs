﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myDietManager.Abstraction.Entities;

namespace myDietManager.IMP.Entities.Converter
{
    public class DietProfileEntityConverter : IConverter<UsersDietProfile, IDietProfile>
    {
        public IDietProfile Convert(UsersDietProfile entity)
        {
            throw new NotImplementedException();
        }

        public UsersDietProfile ConvertBack(IDietProfile pocoObjectToConvert)
        {
            throw new NotImplementedException();
        }
    }
}
