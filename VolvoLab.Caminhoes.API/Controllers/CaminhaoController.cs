using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoLab.Caminhoes.Application.Interfaces;
using VolvoLab.Caminhoes.Application.ViewModels;

namespace VolvoLab.Caminhoes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaminhaoController : ControllerBase
    {
         
        private readonly ICaminhaoService _caminhaoService;

        public CaminhaoController(ICaminhaoService caminhaoService)
        {          
            _caminhaoService = caminhaoService;
        }

        [HttpGet]
        public async Task<IEnumerable<CaminhaoViewModel>> Get()
        {
            var result = await _caminhaoService.GetCaminhoes();
            return result;
        }

        [HttpPost]
        public IActionResult POST(CaminhaoViewModel caminhaoViewModel)
        {
            try
            {
                _caminhaoService.Add(caminhaoViewModel);
                return Ok();
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public CaminhaoViewModel Get(Guid id)
        {
            var result = _caminhaoService.GetById(id);
            return result;
        }

        [HttpPut]
        public IActionResult PUT(CaminhaoViewModel caminhaoViewModel)
        {
            try
            {
                _caminhaoService.Update(caminhaoViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DELETE(Guid id)
        {
            try
            {
                _caminhaoService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Modelos")]
        public IEnumerable<CaminhaoModeloViewModel> GetModelos()
        {
            var result =  _caminhaoService.GetCaminhaoModelos();
            return result;
        }

    }
}
