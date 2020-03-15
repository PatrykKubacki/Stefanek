using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanek.Repositories.Abstraction
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}
