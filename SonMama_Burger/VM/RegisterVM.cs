using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.VM
{
	public class RegisterVM
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public Cinsiyet Cinsiyet { get; set; }
		public DateTime DogumTarihi { get; set; }
		public string PhoneNumber { get; set; }
	}
}
