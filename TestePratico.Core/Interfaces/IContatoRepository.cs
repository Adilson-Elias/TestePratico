using Contato.Business.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestePratico.Core
{
    public interface IContatoRepository
    {
        Task<bool> Insert(ContatoRequest contato);
        Task<bool> Update(ContatoRequest contato);
        Task<bool> Delete(int codigo);
        Task<IEnumerable<ContatoRequest>> ObterTodos();
    }
}
