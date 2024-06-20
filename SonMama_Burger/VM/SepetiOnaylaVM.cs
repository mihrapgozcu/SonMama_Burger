using SonMama_Burger.Models.Entitites;

namespace SonMama_Burger.VM
{
	public class SepetiOnaylaVM
	{
        public Siparis Siparis { get; set; }
        public List<SiparislerMenuler> SiparisMenuler { get; set; }
        public ICollection<Sepet> Sepettekiler { get; set; }
        public List<Sepet> Sepetler { get; set; } 
         public Menu Menu { get; set; }
        public int UserID { get; set; }
        
	}
}
