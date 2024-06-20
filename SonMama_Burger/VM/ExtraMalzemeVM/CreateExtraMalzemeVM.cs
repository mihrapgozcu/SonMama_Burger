using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.VM.ExtraMalzemeVM
{
	public class CreateExtraMalzemeVM
	{
		public string Adi { get; set; }
		public decimal Fiyat { get; set; }
		public Cesit Cesit { get; set; }

		public bool AktifMi {  get; set; }
	}
}
