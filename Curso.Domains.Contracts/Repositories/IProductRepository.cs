using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Curso.Domains.Entities;

namespace Curso.Domains.Contracts.Repositories {
    public interface IProductRepository: IRepository<Product, int> {
        List<Product> GetAll(int page, int rows = 20);
        List<Product> GetAll(Func<Product, bool> specification);
    }
}
