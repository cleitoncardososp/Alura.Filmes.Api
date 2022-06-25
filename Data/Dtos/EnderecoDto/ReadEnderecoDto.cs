using Alura.FilmesApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alura.FilmesApi.Data.Dtos.EnderecoDto
{
    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }

    }
}
