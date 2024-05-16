using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    public class Context : DbContext
    {
      public Context(DbContextOptions<Context> options) : base(options)
        { 
        } 
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Objeto> Objetos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; } 

    }
}
