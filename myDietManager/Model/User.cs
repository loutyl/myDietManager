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
                    case "Height":
                        validationResult = this.ValidateHeight();
                        break;
                    case "DietDuration":
                        validationResult = this.ValidateDietDuration();
                        break;
                    case "WeightGoal":
                        validationResult = this.ValidateWeightGoal();
                        break;
                    default:
                        throw new ApplicationException("Unknown Property being validated.");
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
            return this.CheckWeightRange(this.Weight) ? "The weight entered is incorrect." : string.Empty;
        }

        private bool CheckWeightRange(float weight)
        {
            if (IsKilo)
            {
                return (Math.Abs(weight) ) < 35 || (Math.Abs(weight) > 250);
            }

            return ( Math.Abs(weight) ) < (35 * 2.2f) || ( Math.Abs(weight) > (250 * 2.2f) );
        }

        private string ValidateHeight()
        {
            if (!Regex.IsMatch(this.Height.ToString(CultureInfo.InvariantCulture), @"\d"))
            {
                return "Height can only contain numbers.";
            }
            return (Math.Abs(this.Height) < 100 || Math.Abs(this.Height) > 300)
                ? "The Height enteredis incorrect"
                : string.Empty;

        }

        private string ValidateDietDuration()
        {
            if ( !Regex.IsMatch(this.DietProfile.DietDuration.ToString(), @"\d") )
            {
                return "Only numbers can be entered.";
            }
            return this.DietProfile.DietDuration < 6 ? "The value entered is too low." : string.Empty;
        }

        private string ValidateWeightGoal()
        {
            if ( !Regex.IsMatch(this.DietProfile.WeightGoal.ToString(CultureInfo.InvariantCulture), @"\d") )
            {
                return "Weight can only contain numbers.";
            }
            return this.CheckWeightRange(this.DietProfile.WeightGoal) ? "The weight entered is incorrect." : string.Empty;
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
