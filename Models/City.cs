using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace intro_Address_CRUD_Exam.Models
{
	public class City : BaseObject
	{
		[DisplayName("Şehir Adı")]
		[Required(ErrorMessage = "{0} alanı boş geçilemez.")]
		[StringLength(100, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşabilir.")]
		public string Descp { get; set; }

		[ForeignKey("Country")]
		public int CountryId { get; set; }
		public Country Country { get; set; }

		public ICollection<Ilce> IlceList { get; set; }
	}
}
