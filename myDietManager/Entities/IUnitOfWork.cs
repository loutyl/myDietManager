using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDietManager.Entities
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
