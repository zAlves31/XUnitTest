using stockstoreApi.Domains;

namespace stockstoreApi.Interfaces
{
    public interface IProdcutRespository
    {
        List<Products> Listar();

        Products BuscarPorId(Guid id);

        void Cadastrar(Products products);

        void Atualizar(Guid id, Products products);

        void Deletar(Guid id);
    }
}
