using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SonMama_Burger.Models.Entitites;
using System.Reflection;

namespace SonMama_Burger.DAL
{
	public class BurgerDBContext : IdentityDbContext<AppUser,AppRole,int>
	{
		public BurgerDBContext(DbContextOptions<BurgerDBContext> options) : base(options)
		{

		}

		public DbSet<Menu> Menuler { get; set; }
		public DbSet<Siparis> Siparisler { get; set; }
		public DbSet<ExtraMalzeme> ExtraMalzemeler { get; set; }
		public DbSet<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
		public DbSet<SiparislerMenuler> SiparislerMenuler { get; set; }
		public DbSet<Sepet> Sepettekiler { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(builder);

			//rol 1 user 1 vereceğiz ;
			IdentityUserRole<int> identityUserRole = new IdentityUserRole<int>();
			identityUserRole.UserId = 1;
			identityUserRole.RoleId = 2;

			builder.Entity<IdentityUserRole<int>>(x => x.HasData(identityUserRole));
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer("Data source=MIHRAP-PC\\SQLEXPRESS;initial catalog=SonMama_Burger;integrated security=true;TrustServerCertificate=true");
			base.OnConfiguring(optionsBuilder);
		}
	}
}

