using System.ComponentModel.DataAnnotations.Schema;

namespace SonMama_Burger.Models.Entitites
{
	public class ExtraMalzemelerSiparisler
	{
		public int ID { get; set; }
		[ForeignKey("ExtraMalzeme")]
        
        public int ExtraMalzemeID { get; set; }

        [ForeignKey("Siparis")]
		public int SiparisID { get; set; }
		public ExtraMalzeme ExtraMalzeme { get; set; }
		public Siparis Siparis { get; set; }
	}
}
