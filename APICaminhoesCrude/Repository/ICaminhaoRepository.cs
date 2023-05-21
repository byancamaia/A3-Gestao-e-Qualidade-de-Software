using APICaminhoesCrude.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICaminhoesCrude.Repository
{
    public interface ICaminhaoRepository
    {
        Task<Caminhao> Inserir(Caminhao obj);
        Task Deletar(int id);
        Task<Caminhao> BuscarId(int id);
        Task<Caminhao> Atualizar(int id, Caminhao obj);
        Task<List<Caminhao>> Listar();

    }
}
