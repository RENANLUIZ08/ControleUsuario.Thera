using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Reflection.Emit;

namespace ControleUsuario.Thera.Infra.Registro
{
    public class RegistroConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entidades.Registro>()
            .ToTable("registros")
            .HasKey(p => p.Id);

            modelBuilder.Entity<Domain.Entidades.Registro>()
                .Property(r => r.UsuarioRegistro.UsuarioExpediente)
                .HasColumnName("usuario_expediente")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("ix_usuario_expediente") { IsUnique = true }));

            modelBuilder.Entity<Domain.Entidades.Registro>()
            .Property(r => r.InicioExpediente)
            .HasColumnType("inicio_expediente");

            modelBuilder.Entity<Domain.Entidades.Registro>()
            .Property(r => r.InicioAlmoco)
            .HasColumnType("inicio_almoco");

            modelBuilder.Entity<Domain.Entidades.Registro>()
            .Property(r => r.FimAlmoco)
            .HasColumnType("fim_almoco");

            modelBuilder.Entity<Domain.Entidades.Registro>()
            .Property(r => r.FimExpediente)
            .HasColumnType("fim_expediente");
        }
    }
}
