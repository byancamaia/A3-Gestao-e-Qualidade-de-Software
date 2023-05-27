using APICaminhoesCrude.Controllers;
using APICaminhoesCrude.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICaminhoesCrude.Test.Controllers
{
    public class CrudeControllerTests
    {
        private CaminhaoController _caminhaoController;

        public CrudeControllerTests()
        {
            _caminhaoController = new CaminhaoController(new Mock<ICaminhaoRepository>().Object);
        }


    }
}
