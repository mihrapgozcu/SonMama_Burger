using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonMama_Burger.Models.Entitites;

namespace SonMama_Burger.Configuration
{
	public class MenuCFG : BaseCFG<Menu>
	{
		public override void Configure(EntityTypeBuilder<Menu> builder)
		{
			base.Configure(builder);
			builder.HasData(new Menu() { ID = 1, Adi = "Beefy Burgers", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now,Fotograf= "~/template2/img/yenimenu.jpg" },
						new Menu() { ID = 2, Adi = "Burger Bizz", Fiyat = 270, AktifMi = true, OlusturmaZamani = DateTime.Now, Fotograf = "~/template2/img/iki.jpg" },
						new Menu() { ID = 3, Adi = "Burger Boys", Fiyat = 120, AktifMi = true, OlusturmaZamani = DateTime.Now, Fotograf = "~/template2/img/uc.jpg" },
						new Menu() { ID = 4, Adi = "Crackles Burger", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now, Fotograf = "~/template2/img/dort.jpg" },
						new Menu() { ID = 5, Adi = "Bull Burgers", Fiyat = 200, AktifMi = true, OlusturmaZamani = DateTime.Now, Fotograf = "~/template2/img/bes.jpg" },
						new Menu() { ID = 6, Adi = "Rocket Burgers", Fiyat = 200, AktifMi = true, OlusturmaZamani = DateTime.Now, Fotograf = "~/template2/img/alti.jpg" },
						new Menu() { ID = 7, Adi = "Smokin Burger", Fiyat = 300, AktifMi = true, OlusturmaZamani = DateTime.Now, Fotograf = "~/template2/img/yedi.jpg" },
						new Menu() { ID = 8, Adi = "Delish Burger", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now, Fotograf = "~/template2/img/sekiz.png" },
						new Menu() { ID = 9, Adi = "MAMA Burger", Fiyat = 150, AktifMi = true, OlusturmaZamani = DateTime.Now, Fotograf = "~/template2/img/dokuz.jpeg" }


						);

			builder.Property(x => x.Adi).IsRequired().HasMaxLength(30);

		}
	}
}
