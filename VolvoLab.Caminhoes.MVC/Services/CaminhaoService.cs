using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VolvoLab.Caminhoes.MVC.Extensions;
using VolvoLab.Caminhoes.MVC.Interfaces;
using VolvoLab.Caminhoes.MVC.Models;

namespace VolvoLab.Caminhoes.MVC.Services
{
    public class CaminhaoService : Service, ICaminhaoService 
    {
        private readonly string _uriAPI;
        private readonly string _uriAPIModelos;
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _configuration;

        public CaminhaoService(HttpClient httpClient, 
            IOptions<AppSettings> configuration)
        {
            _configuration = configuration;     

            httpClient.BaseAddress = new Uri(_configuration.Value?.ApiCaminhaoBaseAddress ?? String.Empty);
            _uriAPI = _configuration.Value?.ApiCaminhaoUri ?? String.Empty;
            _uriAPIModelos = _configuration.Value?.ApiCaminhaoModeloUri ?? String.Empty;

            _httpClient = httpClient;

        }


        public async Task Add(CaminhaoViewModel caminhao)
        {
            var caminhaoConteudo = ObterConteudo(caminhao);
            await _httpClient.PostAsync(_uriAPI, caminhaoConteudo);
       
        }

        public async Task<IEnumerable<CaminhaoModeloViewModel>> GetCaminhaoModelos()
        {
            var response = await _httpClient.GetAsync(_uriAPIModelos);

            return await DeserializarObjetoResponse<IEnumerable<CaminhaoModeloViewModel>>(response);
        }


        public async Task<CaminhaoViewModel> GetById(Guid? id)
        {
            var response = await _httpClient.GetAsync(_uriAPI + "/" + id);

            return await DeserializarObjetoResponse<CaminhaoViewModel>(response);
        }



        public async Task<IEnumerable<CaminhaoViewModel>> GetCaminhoes()
        {
            var response = await _httpClient.GetAsync(_uriAPI);

            return await DeserializarObjetoResponse<IEnumerable<CaminhaoViewModel>>(response);

        }

        public async Task Remove(CaminhaoViewModel caminhao)
        {
            await _httpClient.DeleteAsync(_uriAPI + "/" + caminhao.Id.ToString());
        }

        public async Task Update(CaminhaoViewModel caminhao)
        {
            var caminhaoConteudo = ObterConteudo(caminhao);
            await _httpClient.PutAsync(_uriAPI, caminhaoConteudo);
        }

    }
}
