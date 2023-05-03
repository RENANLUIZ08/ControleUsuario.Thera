using ControleUsuario.Thera.Infra.Registro;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Thera.Infra
{
    public class ControleUsuarioContext : DbContext
    {
        public ControleUsuarioContext() : base("name=MyConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RegistroConfiguration.Configure(modelBuilder);
        }

        public DbSet<Domain.Entidades.Registro> Registros { get; set; }
    }
}
