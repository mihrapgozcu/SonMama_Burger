using System.ComponentModel.DataAnnotations.Schema;

namespace SonMama_Burger.Models.Entitites
{
	public class Siparis : BaseClass
	{
		
		public int UserID { get; set; }
		public ICollection<SiparislerMenuler> SiparislerMenuler { get; set; }
		public ICollection<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
		//public AppUser AppUser { get; set; }
	}
}
