using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDietManagerAbstract.Security
{
    public interface IAuthentifactionManager<out T>
    {
        T Authenticate(string username, string password);
    }
}
