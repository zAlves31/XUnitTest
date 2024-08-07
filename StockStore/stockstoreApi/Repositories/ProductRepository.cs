using webapi.Inlock.codeFirst.manha.Contexts;
using stockstoreApi.Interfaces;
using stockstoreApi.Domains;

namespace stockstoreApi.Repositories
{
        public class ProductRepository : IProdcutRespository
        {
            InLockContext ctx = new InLockContext();

            public void Atualizar(Guid id, Products products)
            {
                Products productsBuscado = ctx.Product.Find(id)!;

                if (productsBuscado != null)
                {
                    productsBuscado.Name = products.Name;
                    productsBuscado.Price = products.Price;
                }

                ctx.Product.Update(productsBuscado!);

                ctx.SaveChanges();
            }

            public Products BuscarPorId(Guid id)
            {
                return ctx.Product.FirstOrDefault(e => e.IdProduct == id)!;
            }

            public void Cadastrar(Products products)
            {
                ctx.Product.Add(products);

                ctx.SaveChanges();
            }

            public void Deletar(Guid id)
            {
                Products productsBuscado = ctx.Product.Find(id);

                ctx.Product.Remove(productsBuscado);

                ctx.SaveChanges();
            }


            public List<Products> Listar()
            {
                return ctx.Product.ToList();
            }

      
        }
    }

