using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PousadaApi.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        public int HospedeId { get; set; }
        [JsonIgnore]
        public Hospede? Hospede { get; set; }
        public int AcomodacaoId { get; set; }
        [JsonIgnore]
        public Acomodacao? Acomodacao { get; set; }
        [Required(ErrorMessage = "A data de CheckIn requerida")]
        public DateTime? CheckIn { get; set; }
        [Required(ErrorMessage = "A data de CheckOut é requerida")]
        public DateTime? CheckOut { get; set; }
        public double ValorTotal { get; set; }
        public bool Status { get; set; }
    }
}
