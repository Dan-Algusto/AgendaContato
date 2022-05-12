using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTOs
{
    public class ContatoDTO
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public int Id { get; set; }
    }
}
