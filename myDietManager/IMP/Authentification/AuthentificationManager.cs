using myDietManager.Abstraction.Repositories;
using myDietManager.Abstraction.Security;
using StructureMap;

namespace myDietManager.IMP.Authentification
{
    public class AuthentificationManager : IAuthentifactionManager<User>
    {
        private readonly IContainer _container;
        private readonly IBaseRepository<User> _userRepository;

        public AuthentificationManager(IContainer container)
        {
            this._container = container;
            this._userRepository = this._container.GetInstance<IBaseRepository<User>>();
            
        }

        public User Authenticate(string username, string password)
        {
            return this._userRepository.Get(user => user.UserName.Trim() == username && user.Password.Trim() == password);
        }
    }
}
