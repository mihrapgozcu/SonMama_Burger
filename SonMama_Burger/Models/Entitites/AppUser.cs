using Microsoft.AspNetCore.Identity;
using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.Models.Entitites
{
	public class AppUser : IdentityUser<int>
	{
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public int ConfirmCode { get; set; }
		public Cinsiyet Cinsiyet { get; set; }
		public DateTime DogumTarihi { get; set; }
		public ICollection<Siparis> Siparisler { get; set; }
		public ICollection<Sepet> SepettekiMenuler { get; set; }
	}
}
