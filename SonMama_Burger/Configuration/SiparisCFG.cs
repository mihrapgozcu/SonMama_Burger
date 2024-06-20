using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonMama_Burger.Models.Entitites;

namespace SonMama_Burger.Configuration
{
	public class SiparisCFG : BaseCFG<Siparis>
	{
		public override void Configure(EntityTypeBuilder<Siparis> builder)
		{
			base.Configure(builder);


			//builder.HasOne(x => x.AppUser).WithMany(x => x.Siparisler).HasForeignKey(x => x.ID);
		}

	}
}
