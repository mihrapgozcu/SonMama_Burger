using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonMama_Burger.Models.Entitites;

namespace SonMama_Burger.Configuration
{
	public class SiparislerMenulerCFG: IEntityTypeConfiguration<SiparislerMenuler>
	{
		public void Configure(EntityTypeBuilder<SiparislerMenuler> builder)
		{
			builder.HasOne(x => x.Menu)
				.WithMany(x => x.SiparislerMenuler)
				.HasForeignKey(x => x.MenuID);
			builder.HasOne(x => x.Siparis)
				.WithMany(x => x.SiparislerMenuler)
				.HasForeignKey(x => x.SiparisID);
			builder.HasKey("ID");
		}
	}
}
