using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.Models.Entitites
{
	public class ExtraMalzeme : BaseClass
	{
		public string Adi { get; set; }
		public decimal Fiyat { get; set; }
		public ICollection<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
		public ICollection<Sepet> SepettekiExtraMalzemeler { get; set; }
		public Cesit Cesit { get; set; }
	}
}
