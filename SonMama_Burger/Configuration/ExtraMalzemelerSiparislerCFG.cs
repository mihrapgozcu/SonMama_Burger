using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SonMama_Burger.Models.Entitites;

namespace SonMama_Burger.Configuration
{
	public class ExtraMalzemelerSiparislerCFG:IEntityTypeConfiguration<ExtraMalzemelerSiparisler>
	{
		
			public void Configure(EntityTypeBuilder<ExtraMalzemelerSiparisler> builder)
			{
				//builder.HasKey(x => new { x.SiparisID, x.ExtraMalzemeID });

				builder.HasKey("ID");
			}
		}
	}

