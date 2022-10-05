using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domains.Contracts.Services {
    public interface IDomainService<E, K> {
        List<E> GetAll();
        E GetOne(K id);
        E Add(E item);
        E Modify(E item);
        void Delete(E item);
        void DeleteById(K id);
    }

    public interface IPageableService<E> {
        List<E> GetAll(int page, int rows = 20);
    }

    public interface IDomainPageableService<E, K> : IDomainService<E, K>, IPageableService<E> {

    }

}
