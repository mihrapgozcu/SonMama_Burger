using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonMama_Burger.Models.Entitites;

namespace SonMama_Burger.Configuration
{
	public class RoleCFG : IEntityTypeConfiguration<AppRole>
	{
		public void Configure(EntityTypeBuilder<AppRole> builder)
		{
			builder.HasData(
				 new AppRole() { Name = "Musteri", NormalizedName = "MUSTERI", Id = 1, ConcurrencyStamp = Guid.NewGuid().ToString() },
						new AppRole() { Name = "Admin", NormalizedName = "ADMIN", Id = 2, ConcurrencyStamp = Guid.NewGuid().ToString() }
						);
		}

	}
}
