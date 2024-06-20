using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonMama_Burger.Models.Entitites;
using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.Configuration
{
	public class ExtraMalzemeCFG : BaseCFG<ExtraMalzeme>
	{
		public override void Configure(EntityTypeBuilder<ExtraMalzeme> builder)
		{
			base.Configure(builder);

			builder.Property(x => x.Adi).IsRequired().HasMaxLength(65);

			builder.Property(x => x.Fiyat).IsRequired();

			builder.HasData(new ExtraMalzeme()
			{
				ID = 1,
				Adi = "Ketçap",
				Fiyat = 5,
				Cesit = Cesit.Sos,
				AktifMi = true,
				OlusturmaZamani = DateTime.Now
			},

						new ExtraMalzeme()
						{
							ID = 2,
							Adi = "Mayonez",
							Fiyat = 5,
							Cesit = Cesit.Sos,
							AktifMi = true,
							OlusturmaZamani = DateTime.Now
						},

						new ExtraMalzeme()
						{
							ID = 3,
							Adi = "Ranch Sos",
							Fiyat = 5,
							Cesit = Cesit.Sos,
							AktifMi = true,
							OlusturmaZamani = DateTime.Now
						},
						new ExtraMalzeme()
						{
							ID = 4,
							Adi = "Barbekü Sos",
							Fiyat = 5,
							Cesit = Cesit.Sos,
							AktifMi = true,
							OlusturmaZamani = DateTime.Now
						},
						 new ExtraMalzeme()
						 {
							 ID = 6,
							 Adi = "Sufle",
							 Fiyat = 5,
							 Cesit = Cesit.Tatlı,
							 AktifMi = true,
							 OlusturmaZamani = DateTime.Now
						 },
						  new ExtraMalzeme()
						  {
							  ID = 7,
							  Adi = "Patates Kızartması",
							  Fiyat = 45,
							  Cesit = Cesit.Aperatif,
							  AktifMi = true,
							  OlusturmaZamani = DateTime.Now
						  },
						  new ExtraMalzeme()
						  {
							  ID = 8,
							  Adi = "Mac&Cheese Balls",
							  Fiyat = 60,
							  Cesit = Cesit.Aperatif,
							  AktifMi = true,
							  OlusturmaZamani = DateTime.Now
						  },
						  new ExtraMalzeme()
						  {
							  ID = 9,
							  Adi = "Mozarella Sticks",
							  Fiyat = 70,
							  Cesit = Cesit.Aperatif,
							  AktifMi = true,
							  OlusturmaZamani = DateTime.Now
						  },
						  new ExtraMalzeme()
						  {
							  ID = 10,
							  Adi = "Dondurma",
							  Fiyat = 20,
							  Cesit = Cesit.Tatlı,
							  AktifMi = true,
							  OlusturmaZamani = DateTime.Now
						  });
		}
	
	}
}
