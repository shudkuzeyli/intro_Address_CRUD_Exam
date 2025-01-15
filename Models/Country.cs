using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace intro_Address_CRUD_Exam.Models
{
	public class Country : BaseObject
	{
		[DisplayName("Ülke")]
		[Required(ErrorMessage = "{0} alanı boş geçilemez.")]
		[StringLength(100, ErrorMessage = "{0} alanı en fazla {1} karakterden oluşabilir.")]
		public string Descp { get; set; }

		[Display(Name = "Ülke Kodu")]
		[RegularExpression("^[0-9 ]*$", ErrorMessage = "{0} alanına sadece sayısal değer yazabilirsiniz.")]
		[Required(ErrorMessage = "{0} boş geçilemez.")]
		[StringLength(5, ErrorMessage = "{0} 5 karakterden fazla olamaz.")]
		public string CountryCode { get; set; }

		public ICollection<City> CityList { get; set; }

		[ScaffoldColumn(false)]
		[Browsable(false)]
		public string UlkeKodu => $"{Descp} (+ {CountryCode})"; //"+".Join(Descp, CountryCode);

	}
}
