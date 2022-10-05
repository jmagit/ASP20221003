using Curso.Domains.Contracts.Repositories;
using Curso.Domains.Entities;
using Curso.Infraestructure.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infraestructure.Repositories {
    public class ProductRepository : IProductRepository {
        private readonly TiendaDBContext _context;

        public ProductRepository(TiendaDBContext context) {
            _context = context;
        }

        public List<Product> GetAll() {
            return _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel)
                .ToList();
        }

        public List<Product> GetAll(int page, int rows = 20) {
            return _context.Products.Skip(page * rows).Take(rows)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel)
                .ToList();
        }

        public List<Product> GetAll(Func<Product, bool> specification) {
            var query = _context.Products.AsQueryable();
            query = query.Where(item => specification.Invoke(item)); ;
            return query.ToList();
        }

        public Product GetOne(int id) {
            var product = _context.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel)
                .FirstOrDefault(m => m.ProductId == id);
            if(product == null) {
                throw new Exception("Not found");
            }
            return product;
        }


        public Product Add(Product item) {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Product Modify(Product item) {
            _context.Update(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(Product item) {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public void DeleteById(int id) {
            _context.Remove(new Product() { ProductId = id });
            _context.SaveChanges();
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
            List<Product> rslt = new() {
                new Product() { ProductNumber = "uno", Name = "producto 1", ProductId = 1 },
                new Product() { ProductNumber = "dos", Name = "producto 2", ProductId = 2 },
                new Product() { ProductNumber = "tres", Name = "producto 3", ProductId = 3 }
            };
            return rslt;
        }

        public List<Product> GetAll(int page, int rows = 20) {
            return GetAll().Skip(page * rows).Take(rows).ToList();
        }

        public List<Product> GetAll(Func<Product, bool> specification) {
            return GetAll().Where(specification).ToList();
        }

        public Product GetOne(int id) {
            return new Product() { ProductNumber = "demo", Name = "producto demo", ProductId = id };
        }

        public Product Modify(Product item) {
            throw new NotImplementedException();
        }
    }
}