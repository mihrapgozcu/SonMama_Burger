using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.Models.Entitites
{
	public class Sepet : BaseClass
	{
		public int UrunID { get; set; }
		public int? MenuID { get; set; }
		public Menu? Menu { get; set; }
		
		public int? ExtraMalzemeID { get; set; }
		public ExtraMalzeme? ExtraMalzeme { get; set; }
		public int Adet { get; set; }
		public Boyut Boyut { get; set; }
		public decimal Fiyat { get; set; }
		public int UserID { get; set; }
		public AppUser User { get; set; }
		
	}
}
