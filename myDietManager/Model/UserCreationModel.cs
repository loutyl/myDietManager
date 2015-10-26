using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.Model
{
    public class UserCreationModel
    {
        public ObservableCollection<string> GenderList { get; set; }
        public string SelectedGender { get; set; }
        public Dictionary<string, bool> ValidProperties { get; set; }

        private static ObservableCollection<string> PopulateGenderList() => new ObservableCollection<string> { "Female", "Male" };

        private static Dictionary<string, bool> PopulatePropertiesDictionary() => new Dictionary<string, bool>
        {
            {"LastName", false},
            {"Name", false},
            {"UserName", false},
            {"Age", false},
            {"Weight", false},
            {"Height", false},
            {"DietDuration", false},
            {"WeightGoal", false}
        };

        public UserCreationModel()
        {
            this.GenderList = PopulateGenderList();
            this.SelectedGender = "Female";
            this.ValidProperties = PopulatePropertiesDictionary();
        }
    }
}
