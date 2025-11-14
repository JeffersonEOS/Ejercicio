using auriga2.domain.entities;
using auriga2.domain.models;
using Microsoft.EntityFrameworkCore;
using auriga2.infraestructure.data.configs;

namespace auriga2.infraestructure.data.contexts
{
    public class Auriga2Context : DbContext
    {
        private readonly Func<UserInfoModel> _userInfoFactory;
        private UserInfoModel UserInfo => _userInfoFactory();

        public Auriga2Context(DbContextOptions<Auriga2Context> options) : base(options) { }

        public Auriga2Context(DbContextOptions<Auriga2Context> options,
                               Func<UserInfoModel> userInfoFactory) : base(options)
        {
            this._userInfoFactory = userInfoFactory;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuraciones existentes
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new CatalogConfig());
            modelBuilder.ApplyConfiguration(new ConfigConfig());
            modelBuilder.ApplyConfiguration(new EmailTemplateConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new UserInterestConfig());

            // Configuraciones nuevas (banco, sucursal, cliente, cuenta, transaccion)
            modelBuilder.ApplyConfiguration(new BancoConfig());
            modelBuilder.ApplyConfiguration(new SucursalConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new CuentaConfig());
            modelBuilder.ApplyConfiguration(new TransaccionConfig());
        }

        // DbSets existentes
        public DbSet<UserRoleEntity> UserRoleEntity { get; set; }
        public DbSet<CatalogEntity> CatalogEntity { get; set; }
        public DbSet<ConfigEntity> ConfigEntity { get; set; }
        public DbSet<EmailTemplateEntity> EmailTemplateEntity { get; set; }
        public DbSet<RoleEntity> RoleEntity { get; set; }
        public DbSet<UserEntity> UserEntity { get; set; }
        public DbSet<ProjectEntity> ProjectEntity { get; set; }
        public DbSet<UserInterestEntity> UserInterestEntity { get; set; }

        // DbSets nuevos
        public DbSet<BancoEntity> Bancos { get; set; }
        public DbSet<SucursalEntity> Sucursales { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<CuentaEntity> Cuentas { get; set; }
        public DbSet<TransaccionEntity> Transacciones { get; set; }
    }
}
