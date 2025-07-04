using Microsoft.EntityFrameworkCore;
using PV.Entity.Model;

namespace PV.Repositorio.Contexto
{
    public class DBContexto: DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
    }
}
