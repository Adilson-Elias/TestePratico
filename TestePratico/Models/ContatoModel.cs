using Contato.Business.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePratico.Models
{
    public class ContatoModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }


        public static ContatoModel ToModel(ContatoRequest contato)
        {
            return new ContatoModel
            {
                ID = contato.ID,
                Nome = contato.Nome,
                TelefoneResidencial = contato.TelefoneResidencial,
                TelefoneCelular = contato.TelefoneCelular
            };
        }
    }
}
