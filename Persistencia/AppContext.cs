using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Migrante> Migrantes { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Emergencia> Emergencias { get; set; }
        public DbSet<Novedad> Novedad {get;set;}
        public DbSet<ServicioEntidad> ServiciosEntidades { get; set; }
        public DbSet<CalificacionApp> CalificacionApp {get;set;}
        
        private readonly IConfiguration _configuration;

        public AppContext(DbContextOptions<AppContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            var connectionString = _configuration.GetConnectionString("E-Migrant");
            
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionBuilder.UseSqlServer(connectionString);
            }
            else
            {
                optionBuilder.UseSqlite("Data Source=E-Migrant.db");
            }
        }
    }
}
