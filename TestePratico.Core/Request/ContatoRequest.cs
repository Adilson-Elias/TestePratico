using System;
using System.Collections.Generic;
using System.Text;

namespace Contato.Business.Request
{
    public class ContatoRequest
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }

        public bool IsValido()
        {
            return Nome != string.Empty &&
                TelefoneResidencial != string.Empty;
        }

        public string Erros()
        {
            if (!IsValido())
            {
                string erros = $"Verifique o preenchimento dos campos obrigatórios.";
            }
            return "";
        }
    }
}
