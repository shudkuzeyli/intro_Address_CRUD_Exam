using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace intro_Address_CRUD_Exam.Models
{
	public class BaseObject
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[DisplayName("Sıra No")]
		public int Id { get; set; }

		[DisplayName("Aktiflik")]
		[Required(ErrorMessage = "Aktiflik durumunu seçiniz.")]
		public bool Aktif { get; set; }

		[ScaffoldColumn(false)]
		//Tablo üzerinde referans gösterilen bir alanın üst modele bağlanmayacağını söylüyoruz.(Not: Biz istediğimiz zaman model üzerinden bu veriyi alabiliyor olacağız)
		[Browsable(false)]
		//bu model, bir grid ya da table a datasource oalrak bağlanmışsa arayüzde göster/gösterme seçmemizi sağlıyor
		public string AktifString => Aktif ? "Aktif" : "Pasif";


	}
}
