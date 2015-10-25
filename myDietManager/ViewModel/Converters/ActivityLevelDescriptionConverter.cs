using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace myDietManager.ViewModel.Converters
{
    public class ActivityLevelDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double)) return "Error";

            switch (value.ToString())
            {
                case "14":
                    return "Low - you sit all day.";
                case "15":
                    return "Moderate - e.g. you move a lot during the day.";
                case "16":
                    return "Active - e.g active without sweating";
                case "17":
                    return "Very active - e.g. construction worker.";
            }

            return "Error";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
