using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolaMundoAPI.API.Data.Models
{
    public class Office
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string NameOffice { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public string OfficeHours { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string City { get; set; }
        public string OfficeType{ get; set; }
        public string UrlImage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
