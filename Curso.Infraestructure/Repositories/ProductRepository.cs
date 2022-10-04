using Curso.Domains.Contracts.Repositories;
using Curso.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infraestructure.Repositories {
    public class ProductRepository : IProductRepository {
        public Product Add(Product item) {
            throw new NotImplementedException();
        }

        public void Delete(Product item) {
            throw new NotImplementedException();
        }

        public void DeleteById(int id) {
            throw new NotImplementedException();
        }

        public List<Product> GetAll() {
            throw new NotImplementedException();
        }

        public Product GetOne(int id) {
            throw new NotImplementedException();
        }

        public Product Modify(Product item) {
            throw new NotImplementedException();
        }
    }

    public class ProductRepositoryMock : IProductRepository {
        public Product Add(Product item) {
            throw new NotImplementedException();
        }

        public void Delete(Product item) {
            throw new NotImplementedException();
        }

        public void DeleteById(int id) {
            throw new NotImplementedException();
        }

        public List<Product> GetAll() {
            throw new NotImplementedException();
        }

        public Product GetOne(int id) {
            throw new NotImplementedException();
        }

        public Product Modify(Product item) {
            throw new NotImplementedException();
        }
    }
}