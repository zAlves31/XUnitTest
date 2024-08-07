using Moq;
using stockstoreApi.Domains;
using stockstoreApi.Interfaces;

namespace TestApiUnit
{
    public class ProductsTest
    {
        [Fact]
        public async void Get()
        {
            // Arrange
            List<Products> products = new List<Products>()
            {
                new Products()
                {
                    IdProduct = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Products()
                {
                    IdProduct = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Products()
                {
                    IdProduct = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };
            var mockRepository = new Mock<IProdcutRespository>();

            mockRepository.Setup(x => x.Listar()).ReturnsAsync(products);

            // Act
            var result = await mockRepository.Object.Listar();

            // Assert
            Assert.Equal(3, products.Count);
        }

        [Fact]
        public async void Put()
        {
            // Arrange
            var product = new Products()
            {
                IdProduct = Guid.NewGuid(),
                Name = "Produto 1",
                Price = 10
            };

            var products = new List<Products>();

            var mockRepository = new Mock<IProdcutRespository>();

            mockRepository.Setup(x => x.Cadastrar(product)).Callback<Products>(x => products.Add(product));

            // Act
            mockRepository.Object.Cadastrar(product);

            // Assert
            Assert.Contains(product, products);

        }

        [Fact]
        public async void GetById()
        {
            // Arrange
            List<Products> products = new List<Products>()
            {
                new Products()
                {
                    IdProduct = Guid.NewGuid(),
                    Name = "Cell Phone",
                    Price = 1000.99m,
                },
                new Products()
                {
                    IdProduct = Guid.NewGuid(),
                    Name = "Iphone 15",
                    Price = 7000.99m,
                },
                new Products()
                {
                    IdProduct = Guid.NewGuid(),
                    Name = "Cellzinho",
                    Price = 100.89m,
                }
            };
            var mockRepository = new Mock<IProdcutRespository>();

            mockRepository.Setup(x => x.BuscarPorId(products[0].IdProduct)).ReturnsAsync(products[0]);

            // Act
            var result = await mockRepository.Object.BuscarPorId(products[0].IdProduct);

            // Assert
            Assert.Equal("Cell Phone", result.Name);
        }

        [Fact]
        public async void Delete()
        {
            // Arrange
            List<Products> products = new List<Products>()
            {
                    new Products()
                    {
                        IdProduct = Guid.NewGuid(),
                        Name = "Cell Phone",
                        Price = 1000.99m,
                    },
                    new Products()
                    {
                        IdProduct = Guid.NewGuid(),
                        Name = "Iphone 15",
                        Price = 7000.99m,
                    },
                    new Products()
                    {
                        IdProduct = Guid.NewGuid(),
                        Name = "Cellzinho",
                        Price = 100.89m,
                    }
            };

            var mockRepository = new Mock<IProdcutRespository>();
            mockRepository.Setup(x => x.Deletar(products[0].IdProduct)).Callback(() => products.Remove(products[0]));

            // Act
            await mockRepository.Object.Deletar(products[0].IdProduct);

            // Assert
            Assert.DoesNotContain(products, product => product.Name == "Cell Phone");
        }


    }

}
