using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace intro_Address_CRUD_Exam.Models
{
	public class Address : BaseObject
	{
		[DisplayName("Adres")]
		[Required(ErrorMessage = "{0} alanı boş geçilemez.")]
		[StringLength(20, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşabilir.")]
		public string Tanim { get; set; }

		[DisplayName("Adres Açıklama")]
		[Required(ErrorMessage = "{0} alanı boş geçilemez.")]
		[StringLength(250, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşabilir.")]

		public string AdresAciklama { get; set; }

		[ForeignKey("Country")]
		public int UlkeId { get; set; }

		[ForeignKey("City")]
		public int SehirId { get; set; }

		[ForeignKey("Ilce")]
		public int IlceId { get; set; }


		public Country Country { get; set; }
		 
		public City City { get; set; }

		public Ilce Ilce { get; set; }

	}
}
