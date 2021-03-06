//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyDietManagerEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersDietProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersDietProfile()
        {
            this.UserCalorieNeeds = new HashSet<UserCalorieNeed>();
            this.UserMacronutrients = new HashSet<UserMacronutrient>();
        }
    
        public int UserDietProfileID { get; set; }
        public string ProfileName { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Goal { get; set; }
        public int DietDuration { get; set; }
        public int ActivityLevel { get; set; }
        public double WeightGoal { get; set; }
        public int UserID { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCalorieNeed> UserCalorieNeeds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserMacronutrient> UserMacronutrients { get; set; }
    }
}
