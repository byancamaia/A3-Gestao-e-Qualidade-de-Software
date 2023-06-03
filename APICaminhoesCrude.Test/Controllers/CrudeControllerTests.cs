﻿using APICaminhoesCrude.Context;
using APICaminhoesCrude.Controllers;
using APICaminhoesCrude.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APICaminhoesCrude.Test.Controllers
{
    public class CrudeControllerTests
    {
        private CaminhaoController _caminhaoController;

        public CrudeControllerTests()
        {
            _caminhaoController = new CaminhaoController(new Mock<ICaminhaoRepository>().Object);
        }

        //Fake Repository
        public List<Caminhao> CriarRepository()
        {
            List<Caminhao> caminhoes = new List<Caminhao>() { new Caminhao
            {
                Id = 1,
                AnoFabricacao = 2022,
                AnoModelo = 2023,
                NomeModelo = MarcaModelo.Ford
            },
            new Caminhao
            {
                Id = 2,
                AnoFabricacao = 2022,
                AnoModelo = 2023,
                NomeModelo = MarcaModelo.Mercedes
            },
            new Caminhao
            {
                Id = 3,
                AnoFabricacao = 2022,
                AnoModelo = 2023,
                NomeModelo = MarcaModelo.Scania
            }};

            return caminhoes;
        }

        #region Gets
        [Fact]
        public async Task GetCaminhoesAsync()
        {
            var resp = await _caminhaoController.GetCaminhoes();
            var result = resp as ObjectResult;

            if (result.StatusCode == 200)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async Task GetCaminhaoId_Idencontrado()
        {
            int id = 1;

            var fakeRepository = CriarRepository();
            var mockRepository = new Mock<ICaminhaoRepository>();
            mockRepository.Setup(x => x.BuscarId(id)).Returns(Task.FromResult(fakeRepository.FirstOrDefault(u => u.Id == id)));
            _caminhaoController = new CaminhaoController(mockRepository.Object);

            var resp = await _caminhaoController.GetCaminhaoId(id);
            var result = resp as ObjectResult;

            if (result.StatusCode == 200)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async Task GetCaminhaoId_IdNaoencontrado()
        {
            int id = 10000;

            var fakeRepository = CriarRepository();
            var mockRepository = new Mock<ICaminhaoRepository>();
            mockRepository.Setup(x => x.BuscarId(id)).Returns(Task.FromResult(fakeRepository.FirstOrDefault(u => u.Id == id)));
            _caminhaoController = new CaminhaoController(mockRepository.Object);

            await Assert.ThrowsAsync<Exception>(async () =>
            await _caminhaoController.GetCaminhaoId(id));
        }

        #endregion

        #region Insert

        [Fact]
        public async Task Insert_CaminhaoValidoAsync()
        {
            var resp = await _caminhaoController.Insert(new Caminhao
            {
                Id = 0,
                AnoFabricacao = 2023,
                AnoModelo = 2023,
                NomeModelo = MarcaModelo.Scania
            });

            //Assert
            var result = resp as ObjectResult;

            if (result.StatusCode == 201)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public async Task Insert_AnoModeloInvalido()
        {
            await Assert.ThrowsAsync<Exception>(async () =>
            await _caminhaoController.Insert(new Caminhao
            {
                Id = 0,
                AnoFabricacao = 2022,
                AnoModelo = 2024,
                NomeModelo = MarcaModelo.Scania
            }));
        }

        [Fact]
        public async Task Insert_AnoFabricacaoInvalido()
        {
            await Assert.ThrowsAsync<Exception>(async () =>
            await _caminhaoController.Insert(new Caminhao
            {
                Id = 0,
                AnoFabricacao = 1997,
                AnoModelo = 1998,
                NomeModelo = MarcaModelo.Mercedes
            }));
        }

        [Fact]
        public async Task Insert_AnoFabricacaoNulo()
        {
            await Assert.ThrowsAsync<Exception>(async () =>
            await _caminhaoController.Insert(new Caminhao
            {
                Id = 0,
                AnoFabricacao = 0,
                AnoModelo = 0,
                NomeModelo = MarcaModelo.Scania
            }));
        }

        #endregion

        #region Delete
        [Fact]
        public async Task Delete_IdZeroNulo()
        {
            await Assert.ThrowsAsync<Exception>(async () =>
            await _caminhaoController.Delete(0));
        }
        #endregion
    }
}
