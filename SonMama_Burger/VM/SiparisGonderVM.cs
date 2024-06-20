using SonMama_Burger.Models.Entitites;
using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.VM
{
	public class SiparisGonderVM
	{
		public int MenuID { get; set; }
		public Boyut Boyut { get; set; }
		public string MenuAdi { get; set; }
		public decimal Fiyat { get; set; }
		public int Adet { get; set; }
		public ICollection<Sepet> Sepettekiler { get; set; }
		public int UserID { get; set; }
		public int? ekleme { get; set; }
		public int? MalzemeID { get; set; }
		public string? Sos1ID { get; set; }
		public string? Sos2ID { get; set; }


        public ICollection<Menu> Menuler { get; set; }
      
        public ICollection<ExtraMalzeme> ExtraMalzemeler { get; set; }

    }
}
