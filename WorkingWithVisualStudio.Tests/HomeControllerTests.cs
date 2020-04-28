using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Model;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {

        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[] {
            new Product{Name="P1", Price=275M},
            new Product{Name="P2", Price=48.95M},
            new Product{Name="P3", Price=19.50M},
            new Product{Name="P3", Price=34.95M}
            };

            public void AddProduct(Product p)
            {
                //do nothing - not required for test
            }
        }
        [Fact]
        public void IndexActionModelIsComplete()
        {
            //arrange
            var controller = new HomeController();
            //change repo
            controller.Repository = new ModelCompleteFakeRepository();
            //act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //assert 
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2)
                => p1.Name == p2.Name && p1.Price == p2.Price));
        }



        class ModelCompleteFakeRepositoryPricesUnder50: IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
            new Product{Name="P1", Price=5M},
            new Product{Name="P2", Price=48.95M},
            new Product{Name="P3", Price=19.50M},
            new Product{Name="P3", Price=34.95M}
            };

            public void AddProduct(Product p)
            {
                //do nothing - not required for test
            }

        }

        [Fact]
        public void IndexActionModelIsCompletePricesUnder50()
        {
            //Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepositoryPricesUnder50();

            //Act 
            var model = (controller.Index() as ViewResult)?.ViewData.Model as
                IEnumerable<Product>;

            //assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class ModelCompleteFakeParamRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product P)
            {
                //do nothing - not required for test
            }

        }

        [Theory]
        [InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]
        public void InexActionModelIsComplete(decimal price1, decimal price2, decimal price3,
            decimal price4)
        {
            //arrange 
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeParamRepository
            {
                Products= new Product[]
                {
                    new Product {Name = "P1", Price = price1},
                    new Product {Name = "P2", Price = price2},
                    new Product {Name = "P3", Price = price3},
                    new Product {Name = "P4", Price = price4},
                }
            };

            //act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
        
    }
}
