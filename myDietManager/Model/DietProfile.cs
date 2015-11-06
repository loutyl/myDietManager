using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using myDietManager.Class;

namespace myDietManager.Model
{
    public enum Goal
    {
        Lose,
        Gain
    };

    [Serializable]
    public class DietProfile : IDataErrorInfo
    {
        public string ProfileName { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public Goal Goal { get; set; }
        public int DietDuration { get; set; }
        public int ActivityLevel { get; set; } = 14;
        public float WeightGoal { get; set; }
        public int DietProfileId { get; set; }
        public int UserId { get; set; }
        public CalorieNeeds CalorieNeeds { get; set; }
        public Macronutrients Macros { get; set; }

        public string this[string attributeName]
        {
            get
            {
                switch (attributeName)
                {
                    case "ProfileName":
                        return string.IsNullOrEmpty(this.ProfileName)
                            ? "A profile name must be entered"
                            : string.Empty;
                    case "Weight":
                        return (Math.Abs(this.Weight) < (35 * 2.2f) || Math.Abs(this.Weight) > (250 * 2.2f))
                            ? "The weight entered is incorrect."
                            : string.Empty;
                    case "Height":
                        return (Math.Abs(this.Height) < 100 || Math.Abs(this.Height) > 300)
                            ? "The height entered is incorrect."
                            : string.Empty;
                    case "DietDuration":
                        return this.DietDuration < 6
                            ? "The value entered is too low."
                            : string.Empty;
                    case "WeightGoal":
                        return (Math.Abs(this.Weight) < (35 * 2.2f) || Math.Abs(this.Weight) > (250 * 2.2f))
                            ? "The weight entered is incorrect."
                            : string.Empty;
                    default:
                        throw new ApplicationException("Unknow attribute being validated.");
                }
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public void FinalizeProfileCreation()
        {
            this.CalorieNeeds = CalorieNeeds.GetProfileCalorieNeeds(this);
            this.Macros = Macronutrients.GetMacronutrientsRatios(this);
        }
    }
}

