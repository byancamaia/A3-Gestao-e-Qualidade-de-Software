using APICaminhoesCrude.Repository;
using Microsoft.AspNetCore.Mvc;

namespace c.Controllers
{
    [ApiController]
    [Route("api/Caminhao")]
    public class CaminhaoController : ControllerBase
    {

        private ICaminhaoRepository _caminhaoRepository { get; set; }

        public CaminhaoController(ICaminhaoRepository caminhaoRepository)
        {
            _caminhaoRepository = caminhaoRepository;
        }


    }
}
