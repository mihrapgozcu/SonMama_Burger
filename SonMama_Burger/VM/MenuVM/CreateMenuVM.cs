namespace SonMama_Burger.VM.MenuVM
{
	public class CreateMenuVM
	{
		public string Adi { get; set; }
		public decimal Fiyat { get; set; }
		public IFormFile Image { get; set; }
		public bool AktifMi { get; set; }
	}
}
