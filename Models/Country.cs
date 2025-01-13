using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace intro_Address_CRUD_Exam.Models
{
	public class Country : BaseObject
	{
		[DisplayName("Ülke")]
		[Required (ErrorMessage ="{0} alanı boş geçilemez.")]
		[StringLength(100, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşabilir.")]
		public string Descp { get; set; }

		public ICollection<City> CityList { get; set; }

		[ScaffoldColumn(false)]
		[Browsable(false)]
		public string UlkeKodu => Descp + " (+90)";

	}
}
