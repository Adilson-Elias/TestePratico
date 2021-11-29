using Contato.Business.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Core;

namespace TestaPraticoCommand.Contato
{
    public class ContatoCommand
    {
        private readonly IContatoRepository contatoRepository;

        public ContatoCommand(IContatoRepository contatoRepository)
        {
            this.contatoRepository = contatoRepository;
        }
        public async Task<bool> InserirCommand(ContatoRequest contato)
        {
            return await contatoRepository.Insert(contato);
        }
    }
}
