namespace SonMama_Burger.Models.Entitites
{
	public class BaseClass
	{
		public int ID { get; set; }
		public DateTime OlusturmaZamani { get; set; }
		public DateTime? GuncellemeZamani { get; set; }
		public DateTime? SilinmeZamani { get; set; }
		public bool AktifMi { get; set; }

        
    }
}
