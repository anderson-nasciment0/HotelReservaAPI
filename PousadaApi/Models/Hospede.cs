using System.ComponentModel.DataAnnotations;

namespace PousadaApi.Models
{
    public class Hospede
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é requerida")]
        [StringLength(80)]
        public string? Nome { get; set; }
        [StringLength(80)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "O telefone é requerida")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "O documento é requerida")]
        public string? Documento { get; set; }
    }
}
