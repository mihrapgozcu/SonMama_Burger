using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.Models.Entitites
{
	public class SiparislerMenuler 
	{
		public int ID { get; set; }
		public int SiparisID { get; set; }
		public int MenuID { get; set; }
		public Siparis Siparis { get; set; }
		public Menu Menu { get; set; }
		public int Adet { get; set; }
		public Boyut Boyut { get; set; }
		public decimal TotalFiyat { get; set; }
		public DateTime OlusturmaZamani { get; set; }
	}
}
