using SonMama_Burger.Models.Entitites;
using SonMama_Burger.Models.Enum;

namespace SonMama_Burger.VM
{
	public class SiparisOlusturVM
	{
		public ICollection<Menu> Menuler { get; set; }
		public Boyut Boyut { get; set; }
		public ICollection<ExtraMalzeme> ExtraMalzemeler { get; set; }
	}
}
