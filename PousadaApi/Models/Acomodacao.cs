using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PousadaApi.Models
{
    public class Acomodacao
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é requerido")]
        [StringLength(80)]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "A descrição é requerida")]
        [StringLength(80)]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "A capacidade é requerida")]
        [Range(1,10, ErrorMessage = "A capacidade deve ser entre 1 e 10 pessoas")]
        public int Capacidade { get; set; }
        [Range(50, 100, ErrorMessage = "O preço da diaria deve ser entre 50 e 100 reais")]
        public double PrecoDiaria { get; set; }
        public bool Status {  get; set; }
    }
}
