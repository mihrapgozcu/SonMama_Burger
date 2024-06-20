using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonMama_Burger.Models.Entitites;

namespace SonMama_Burger.Configuration
{
	public class UserCFG : IEntityTypeConfiguration<AppUser>
	{
		public void Configure(EntityTypeBuilder<AppUser> builder)
		{
			AppUser uye = new AppUser
			{
				Id = 1,
				Ad = "Cevdet",
				Soyad = "Heredot",
				Email = "cevdet@deneme.com",
				NormalizedEmail = "CEVDET@DENEME.COM",
				UserName = "cevdet@deneme.com",
				NormalizedUserName = "CEVDET@DENEME.COM",
				EmailConfirmed = true,
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				SecurityStamp = Guid.NewGuid().ToString()


			};
			PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
			uye.PasswordHash = passwordHasher.HashPassword(uye, "ceVdo_123");

			builder.HasData(uye);
		}

	}
}
