using DesafioAPIRocketseat.Communications.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioAPIRocketseat.Communications.Entities
{
    public class BibliotecaDB : DbContext
    {
        public BibliotecaDB(DbContextOptions<BibliotecaDB> options) : base(options)
        {

        }
        public DbSet<RequestLivroCreateJson> Livros { get; set; }
    }
}
