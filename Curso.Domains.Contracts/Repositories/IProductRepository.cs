using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domains.Entities;

namespace Curso.Domains.Contracts.Repositories {
    public interface IProductRepository: IRepository<Product, int> {
    }
}
