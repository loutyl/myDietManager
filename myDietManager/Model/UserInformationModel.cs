﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;


namespace myDietManager.Model
{
    public class UserInformationModel
    {
        public ObservableCollection<string> GenderList { get; set; }
        public string SelectedGender { get; set; }
        public Dictionary<string, bool> ValidProperties { get; set; }
        public double ViewWidth { get; set; } = 600;
        public double ViewHeight { get; set; } = 400;

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

        public UserInformationModel()
        {
            this.GenderList = PopulateGenderList();
            this.SelectedGender = "Female";
            this.ValidProperties = PopulatePropertiesDictionary();
        }
    }
}