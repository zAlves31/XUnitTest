using Moq;
using stockstoreApi.Domains;
using stockstoreApi.Interfaces;

namespace testApiUnit
{
    public class ProductsTest
    {
        //Indica que o metodo e teste de unidade
        [Fact]
        public async void Listar()
        {
            // Arrange
            List<Products> products = new List<Products>()
            {
                new Products()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Products()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Products()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.GetProducts()).ReturnsAsync(products);

            // Act
            var result = await mockRepository.Object.GetProducts();

            // Assert
            Assert.Equal(3, products.Count);
        }

        [Fact]
        public async void Cadastrar()
        {
            // Arrange
            var product = new Product()
            {
                ProductId = Guid.NewGuid(),
                Name = "Produto 1",
                Price = 10
            };

            var products = new List<Product>();

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.CreateProduct(product)).Callback<Product>(x => products.Add(product));

            // Act
            mockRepository.Object.CreateProduct(product);

            // Assert
            Assert.Contains(product, products);

        }

       
        [Fact]
        public async void BuscarPorId()
        {
            // Arrange
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };

            var mockRepository = new Mock<IProductsRepository>();

            mockRepository.Setup(x => x.GetProductById(products[0].ProductId)).ReturnsAsync(products[0]);

            // Act
            var result = await mockRepository.Object.GetProductById(products[0].ProductId);

            // Assert
            Assert.Equal("Cell Phone", result.Name);
        }

       
        [Fact]
        public async void Deletar()
        {
            // Arrange
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.DeleteProduct(products[0].ProductId)).Callback(() => products.Remove(products[0]));

            // Act
            await mockRepository.Object.DeleteProduct(products[0].ProductId);

            // Assert
            Assert.DoesNotContain(products, product => product.Name == "Cell Phone");
        }

        [Fact]
        public async void Atualizar()
        {
            // Arrange
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };

            var newProductData = new Product()
            {
                ProductId = products[0].ProductId,
                Name = "Call me on my cell phone",
                Price = 10.45m
            };

            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(x => x.UpdateProduct(newProductData)).Callback(() =>
            {
                products[0].Name = "Call me on my cell phone";
                products[0].Price = 10.45m;
            });

            // Act
            await mockRepository.Object.UpdateProduct(newProductData);

            // Assert
            Assert.Contains(products, product => product.Name == "Call me on my cell phone");

        }
    }


}
