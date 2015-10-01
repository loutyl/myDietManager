namespace myDietManager.Model
{
    public class User
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        internal DietProfile DietProfile { get; set; }

        public User() { }

        public User(UserInformations informations)
        {
            this.LastName = informations.LastName;
            this.Name = informations.Name;
            this.UserName = informations.UserName;
            this.Age = informations.Age;
            this.Gender = informations.Gender;
            this.Weight = informations.Weight;
            this.Height = informations.Height;
        }
    }
}
