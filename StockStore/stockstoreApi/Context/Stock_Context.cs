using Microsoft.EntityFrameworkCore;
using stockstoreApi.Domains;

namespace webapi.Inlock.codeFirst.manha.Contexts
{
    public class InLockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<Products> Product { get; set; }

        /// <summary>
        /// Define as opcoes de construcao do banco(String Conexao)
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as definicoes</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MHF127S; Database=stockstore_manha; user id=sa; Pwd=Senai@134; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
