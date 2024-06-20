using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonMama_Burger.Models.Entitites;

namespace SonMama_Burger.Configuration
{
	public class BaseCFG<T>: IEntityTypeConfiguration<T> where T : BaseClass
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.OlusturmaZamani).IsRequired();
			builder.Property(x => x.AktifMi).IsRequired();
		}
	}
}
