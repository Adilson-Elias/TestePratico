using Contato.Business.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.Core.DTO
{
    public class ContatoDTO
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone_residencial { get; set; }
        public string telefone_celular { get; set; }


        public ContatoRequest ToModel()
        {
            return new ContatoRequest
            {
                ID = id,
                Nome = nome,
                TelefoneResidencial = telefone_residencial,
                TelefoneCelular = telefone_celular
            };
        }
    }
}
