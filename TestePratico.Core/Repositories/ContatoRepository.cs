using Contato.Business.Request;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePratico.Core.Connection;
using TestePratico.Core.DTO;

namespace TestePratico.Core
{
    public class ContatoRepository : IContatoRepository
    {

        public async Task<bool> Insert(ContatoRequest contato)
        {
            using (var con = Access.GetSqlConnection())
            {
                string query = "INSERT INTO contato (nome, telefone_residencial, telefone_celular) " +
                    $"VALUES ('{contato.Nome}','{contato.TelefoneResidencial}', '{contato.TelefoneCelular}');";

                var rowsAffected = await con.ExecuteAsync(query, null, null, null, System.Data.CommandType.Text);
                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<ContatoRequest>> ObterTodos()
        {
            using (var con = Access.GetSqlConnection())
            {
                string query = "SELECT * FROM contato;";
                var result = await con.QueryAsync<ContatoDTO>(query);

                return result?.Select(x => x.ToModel());
            }
        }

        public async Task<bool> Update(ContatoRequest contato)
        {
            using (var con = Access.GetSqlConnection())
            {
                string query = "UPDATE contato SET nome = @nome, telefone_residencial = @telefone, telefone_celular = @celular WHERE id = @id;";
                var objParam = new
                {
                    id = contato.ID,
                    nome = contato.Nome,
                    telefone = contato.TelefoneResidencial,
                    celular = contato.TelefoneCelular
                };

                var rowsAffected = await con.ExecuteAsync(query, objParam, null, null, System.Data.CommandType.Text);
                return rowsAffected > 0;
            }
        }
        public async Task<bool> Delete(int codigo)
        {
            using (var con = Access.GetSqlConnection())
            {
                string query = "DELETE FROM contato WHERE id = @id;";
                var objParam = new
                {
                    id = codigo
                };

                var rowsAffected = await con.ExecuteAsync(query, objParam, null, null, System.Data.CommandType.Text);
                return rowsAffected > 0;
            }
        }
    }
}
