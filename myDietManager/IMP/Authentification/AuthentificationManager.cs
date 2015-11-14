using myDietManager.Abstraction.Security;
using myDietManager.IMP.Entities.Repositories;
using StructureMap;

namespace myDietManager.IMP.Authentification
{
    public class AuthentificationManager : IAuthentifactionManager<User>
    {
        private readonly IContainer _container;

        public AuthentificationManager(IContainer container)
        {
            this._container = container;
        }

        public User Authenticate(string username, string password)
        {
            var userRepository = this._container.GetInstance<UserRepository>();

            return userRepository.FindUserByCredentials(username, password);
        }
    }
}
