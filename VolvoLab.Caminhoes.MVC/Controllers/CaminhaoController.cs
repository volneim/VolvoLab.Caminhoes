using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoLab.Caminhoes.MVC.Interfaces;
using VolvoLab.Caminhoes.MVC.Models;

namespace VolvoLab.Caminhoes.MVC.Controllers
{
    public class CaminhaoController : Controller
    {
        private readonly ILogger<CaminhaoController> _logger;
        private readonly ICaminhaoService _caminhaoService;


        public CaminhaoController(ICaminhaoService caminhaoService, ILogger<CaminhaoController> logger)
        {
            _caminhaoService = caminhaoService;
            _logger = logger;
        }

        // GET: CaminhaoController
        public async Task<ActionResult> Index()
        {
            await CarregarViewBags();
            var _pageViewModel = await CarregaPageViewModel();
            return View(_pageViewModel);
        }

        // POST: CaminhaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CaminhaoViewModel caminhaoViewModel)
        {
           try
            {
                caminhaoViewModel.Id = Guid.NewGuid();

                if (!ModelState.IsValid)
                {
                    await CarregarViewBags();
                    var _pageViewModel = await CarregaPageViewModel();
                    return View("Index",_pageViewModel);
                }

                await _caminhaoService.Add(caminhaoViewModel);
                return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["mesgErro"] = "Ocorrreu um erro ao localizar o cadastro.";
                return RedirectToAction("index");
            }

        }

        // GET: CaminhaoController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            try
            {
                var caminhaoViewModel = await _caminhaoService.GetById(id);
                await CarregarViewBags();
                return View(caminhaoViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["mesgErro"] = "Ocorrreu um erro ao abrir o cadastro.";
                return RedirectToAction("index");
            }

        }

        // POST: CaminhaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CaminhaoViewModel caminhaoViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await CarregarViewBags();
                    var _pageViewModel = await CarregaPageViewModel();
                    return View("Index", _pageViewModel);
                }

                await _caminhaoService.Update(caminhaoViewModel);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                TempData["mesgErro"] = "Ocorrreu um erro ao alterar o cadastro.";
                return RedirectToAction("index");
            }
        }        

        // POST: CaminhaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(CaminhaoViewModel caminhaoViewModel)
        {
            var msgErro = new List<String>();

            try
            {
                await _caminhaoService.Remove(caminhaoViewModel);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                msgErro.Add("Ocorrreu um erro ao localizar o cadastro.");
            }

            TempData["mesgErro"] = msgErro;
            return RedirectToAction("index");
        }

        private async Task CarregarViewBags()
        {
            var _modeloAnoAtual = DateTime.Now.Year.ToString();
            var _modeloProximoAno = DateTime.Now.AddYears(1).Year.ToString();

            var _caminhaoAnoModelo = new[]
                       {
                           new SelectListItem { Value = _modeloAnoAtual, Text = _modeloAnoAtual},
                           new SelectListItem { Value = _modeloProximoAno, Text = _modeloProximoAno}
                       };
            var _caminhaoModelos = await _caminhaoService.GetCaminhaoModelos();

            ViewBag.caminhaoAnoModelo = new SelectList(_caminhaoAnoModelo, "Value", "Text");
            ViewBag.CaminhaoModelos = new SelectList(_caminhaoModelos, "Nome", "Nome");
        }

        private async Task<PageViewModel<CaminhaoViewModel>> CarregaPageViewModel()
        {
            var _pageViewModel = new PageViewModel<CaminhaoViewModel>
            {
                List = await _caminhaoService.GetCaminhoes(),
                Obj = new CaminhaoViewModel()
                {
                    AnoFab = DateTime.Now.Year
                }
            };

            return _pageViewModel;
        }
    }
}
