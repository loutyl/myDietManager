using System;
using myDietManager.Abstraction.Entities;
using StructureMap;

namespace myDietManager.IMP.Entities.Converter
{
    public class UserEntityConverter : IConverter<User, IUser>
    {
        private readonly IContainer _container;

        public UserEntityConverter(IContainer container)
        {
            this._container = container;
        }

        public IUser Convert(User entity)
        {
            var pocoUser = this._container.GetInstance<IUser>();

            pocoUser.UserID = entity.UserID;
            pocoUser.UserName = entity.UserName;
            pocoUser.Password = entity.Password;
            pocoUser.LastName = entity.LastName;
            pocoUser.Name = entity.Name;
            pocoUser.Age = entity.Age;
            pocoUser.Gender = entity.Gender;
            pocoUser.Role = entity.Role;

            return pocoUser;
        }

        public User ConvertBack(IUser objectToConvertBack)
        {
            throw new NotImplementedException();
        }
    }
}
