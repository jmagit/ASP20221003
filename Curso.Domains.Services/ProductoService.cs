using Curso.Domains.Contracts.Services;
using Curso.Domains.Contracts.Repositories;
using Curso.Domains.Entities;
using System.Linq.Expressions;

namespace Curso.Domains.Services {
    public class ProductoService : IProductService {
        private readonly IProductRepository dao;

        public ProductoService(IProductRepository dao) {
            this.dao = dao;
        }
        public Product Add(Product item) {
            if(item.IsInvalid)
                throw new Exception("Error");
            return dao.Add(item);
        }

        public void Delete(Product item) {
            if(item.IsInvalid)
                throw new Exception("Error");
            dao.Delete(item);
        }

        public void DeleteById(int id) {
            dao.DeleteById(id);
        }

        public List<Product> GetAll() {
            return dao.GetAll();
        }

        public List<Product> GetAll(int page, int rows = 20) {
            return dao.GetAll(page, rows);
        }

        public List<Product> GetAll(Func<Product, bool> specification) {
            return dao.GetAll(specification);
        }

        public Product GetOne(int id) {
            return dao.GetOne(id);
        }

        public Product Modify(Product item) {
            if(item.IsInvalid)
                throw new Exception("Error");
            return dao.Modify(item);
        }

        // Métodos propios del dominio
    }
}