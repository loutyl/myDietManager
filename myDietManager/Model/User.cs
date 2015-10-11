using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace myDietManager.Model
{
    public class User: IDataErrorInfo
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public float Weight { get; set; }
        public bool IsPound { get; set; }
        public bool IsKilo { get; set; } = true;
        public float Height { get; set; }
        internal DietProfile DietProfile { get; set; }

        #region Interface Implementation

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string propertyName]
        {
            get
            {
                string validationResult;

                switch (propertyName)
                {
                    case "Name":
                        validationResult = ValidateName(this.Name);
                        break;
                    case "LastName":
                        validationResult = ValidateName(this.LastName);
                        break;
                    case "UserName":
                        validationResult = this.ValidateUserName();
                        break;
                    case "Age":
                        validationResult = this.ValidateAge();
                        break;
                    case "Weight":
                        validationResult = this.ValidateWeight();
                        break;
                    default:
                        throw new ApplicationException("Unknown Property being validated on Product.");
                }
                return validationResult;
            }
        }

        private static string ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) )
            {
                return "A name must be entered.";
            }
            return Regex.IsMatch(name, @"\d") ? "Name cannot contain numbers." : string.Empty;
        }

        private string ValidateUserName() => string.IsNullOrEmpty(this.UserName) ? "A name must be entered." : string.Empty;

        private string ValidateAge()
        {
            if (!Regex.IsMatch(this.Age.ToString(), @"\d"))
            {
                return "Age is in the wrong format";
            }
            if (this.Age < 13 || this.Age > 65)
            {
                return "Age must be within 13 and 65.";
            }
            return string.Empty;
        }

        private string ValidateWeight()
        {
            if (!Regex.IsMatch(this.Weight.ToString(CultureInfo.InvariantCulture), @"\d"))
            {
                return "Weight can only contain numbers.";
            }
            if ((Math.Abs(this.Weight)) <= 0)
            {
                return "Weight must be entered.";
            }

            return this.CheckWeightRange() ? "The weight entered is incorrect." : string.Empty;
        }

        private bool CheckWeightRange()
        {
            if (IsKilo)
            {
                return (Math.Abs(this.Weight)) < 35 || (Math.Abs(this.Weight) > 250);
            }

            return ( Math.Abs(this.Weight) ) < (35 * 2.2f) || ( Math.Abs(this.Weight) > (250 * 2.2f) );
        }

        #endregion

        private void CreateUserCalorieNeeds()
        {
            this.DietProfile.CalorieNeeds = new CalorieNeeds
            {
                MaintencanceCalories = (int)(!this.IsPound
                    ? (this.Weight * 2.2f) * this.DietProfile.ActivityLevel
                    : this.Weight * this.DietProfile.ActivityLevel)
            };

            this.DietProfile.CalorieNeeds.DailyCalories = this.DietProfile.IsGain
                ? (this.DietProfile.CalorieNeeds.MaintencanceCalories + 250)
                : (this.DietProfile.CalorieNeeds.MaintencanceCalories - 500);
        }

        private void CreateUserMacroRatio() => this.DietProfile.Macros = new Macronutrients
        {
            Carbohydrate = new Carbohydrate((int)(this.DietProfile.CalorieNeeds.DailyCalories * 0.4)),
            Protein = new Protein((int)(this.DietProfile.CalorieNeeds.DailyCalories * 0.4)),
            Fat = new Fat((int)(this.DietProfile.CalorieNeeds.DailyCalories * 0.2))
        };

        public void FinalizeUserCreation()
        {
            this.CreateUserCalorieNeeds();
            this.CreateUserMacroRatio();
        }
        
    }
}
