namespace myDietManager.Model
{
    public class User
    {   
        public string UserName { get; set;}
        public string LastName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public float Weight { get; set; }
        internal DietProfile DietProfile { get; set; }

        public User()
        {
            this.DietProfile = new DietProfile();
        }
    }
}
