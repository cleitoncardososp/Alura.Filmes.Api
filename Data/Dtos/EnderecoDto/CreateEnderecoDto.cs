using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.FilmesApi.Data.Dtos.EnderecoDto
{
    public class CreateEnderecoDto
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

    }
}