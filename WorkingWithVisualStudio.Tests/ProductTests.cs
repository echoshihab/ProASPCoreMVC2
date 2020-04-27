using System;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Model;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //Arrange
            var p = new Product { Name = "Test", Price = 100M };

            //ACT
            p.Name = "New Name";

            //Assert
            Assert.Equal("New Name", p.Name);
        }
        [Fact]
        public void CanChangeProductPrice()
        {
            //ARRANGE
            var p = new Product { Name = "Test", Price = 100M };

            //Act
            p.Price = 200M;

            //Assert
            Assert.Equal(200M, p.Price);

        }

    }
}
