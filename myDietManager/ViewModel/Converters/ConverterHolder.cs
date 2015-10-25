using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.ViewModel.Converters
{
    public static class ConverterHolder
    {
        public static readonly ActivityLevelDescriptionConverter ActivityDescriptionConverter =
            new ActivityLevelDescriptionConverter();
    }
}
