namespace SonMama_Burger.Models.Entitites
{
	public class Menu : BaseClass
	{
		public int MenuID { get; set; }
		public string Adi { get; set; }
		public decimal Fiyat { get; set; }
		public string? Fotograf { get; set; }
		public ICollection<SiparislerMenuler> SiparislerMenuler { get; set; }
		public ICollection<Sepet> SepettekiMenuler { get; set; }
	}
}
