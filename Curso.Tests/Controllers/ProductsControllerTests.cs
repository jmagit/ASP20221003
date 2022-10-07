using Microsoft.VisualStudio.TestTools.UnitTesting;
using Curso.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domains.Services;
using Curso.Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Curso.Domains.Entities;

namespace Curso.Controllers.Tests {
    [TestClass()]
    public class ProductsControllerTests {
        [TestMethod()]
        public void ProductsControllerTest() {

        }

        [TestMethod()]
        public void IndexTest() {
            var cntr = new ProductsController(null, new ProductoService(new ProductRepositoryMock()));

            var result = cntr.Index();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(3, ((result as ViewResult).Model as List<Product>).Count);

        }

        [TestMethod()]
        public void ListadoTest() {

        }

        [TestMethod()]
        public void AjaxTest() {

        }

        [TestMethod()]
        public void FragmentoTest() {

        }

        [TestMethod()]
        public void FragmentoJsonTest() {

        }

        [TestMethod()]
        public void DetailsTest() {

        }

        [TestMethod()]
        public void PhotoTest() {

        }

        [TestMethod()]
        public void DatosTest() {

        }

        [TestMethod()]
        public void CreateTest() {

        }

        [TestMethod()]
        public void CreateTest1() {

        }

        [TestMethod()]
        public void EditTest() {

        }

        [TestMethod()]
        public void EditTest1() {

        }

        [TestMethod()]
        public void DeleteTest() {

        }

        [TestMethod()]
        public void DeleteConfirmedTest() {

        }
    }
}