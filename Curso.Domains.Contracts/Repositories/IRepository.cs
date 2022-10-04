using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domains.Contracts.Repositories {
    public interface IRepository<E, K> {
        List<E> GetAll();
        E GetOne(K id);
        E Add(E item);
        E Modify(E item);
        void Delete(E item);
        void DeleteById(K id);
    }
}
