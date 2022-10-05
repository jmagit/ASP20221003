using Curso.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Domains.Contracts.Services {
    public interface IProductService : IDomainService<Product, int>, IPageableService<Product> {
        List<Product> GetAll(Func<Product, bool> specification);

    }
}
