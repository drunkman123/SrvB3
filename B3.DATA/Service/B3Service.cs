using B3.DATA.Interface;
using B3.DATA.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static B3.DATA.Model.ListarCNPJFiisModel;
using static B3.DATA.Model.ListarTodasAcoesModel;
using static B3.DATA.Model.ListarTodosFiisModel;

namespace B3.DATA.Service
{
    public class B3Service : IB3Service
    {

        readonly IConfiguration Configuration;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _listarTodasAcoesUrl = "";
        private string _listarTodosFiisUrl = "";
        private string _listarTodosCnpjsFiiUrl = "";

        public B3Service(IConfiguration Configuration, IHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _httpClientFactory = httpClientFactory;
            this.Configuration = Configuration;
            _listarTodasAcoesUrl = ConfigurationBinder.GetValue<string>(Configuration, "listarTodasAcoesUrl");
            _listarTodosFiisUrl = ConfigurationBinder.GetValue<string>(Configuration, "listarTodosFiisUrl");
            _listarTodosCnpjsFiiUrl = ConfigurationBinder.GetValue<string>(Configuration, "listarTodosCnpjsFiiUrl");

        }
        public async Task<Acoes> ListarTodasAcoes()
        {
            //var httpClient = _httpClientFactory.CreateClient("ListarB3");
            var httpClient = _httpClientFactory.CreateClient();
            var content = await httpClient.GetAsync(_listarTodasAcoesUrl);
            if (!content.IsSuccessStatusCode)
            {
            }//depois dos retries, caso mesmo assim nao funcionar, pode pegar o erro aqui

            var obj = content.Content.ReadAsStringAsync();
            Acoes todasAcoes = JsonConvert.DeserializeObject<Acoes>(obj.Result);
            return todasAcoes;
        }
        
        public async Task<Fiis> ListarTodosFiis()
        {
            //var httpClient = _httpClientFactory.CreateClient("ListarB3");
            var httpClient = _httpClientFactory.CreateClient();
            var content = await httpClient.GetAsync(_listarTodosFiisUrl);
            if (!content.IsSuccessStatusCode)
            {
            }//depois dos retries, caso mesmo assim nao funcionar, pode pegar o erro aqui

            var obj = content.Content.ReadAsStringAsync();
            Fiis todosFiis = JsonConvert.DeserializeObject<Fiis>(obj.Result);
            await GetCNPJFii(todosFiis, httpClient);
            return todosFiis;
        }

        public async Task<Fiis> GetCNPJFii(Fiis fiis, HttpClient conexao)
        {
            foreach (var fii in fiis.results)
            {
                string texto = "{ \"typeFund\":7,\"identifierFund\":\"" + fii.acronym + "\"}";
                byte[] textoAsBytes = Encoding.ASCII.GetBytes(texto);
                string resultado = System.Convert.ToBase64String(textoAsBytes);
                var content2 = await conexao.GetAsync(_listarTodosCnpjsFiiUrl + resultado);
                if (!content2.IsSuccessStatusCode)
                {
                }//depois dos retries, caso mesmo assim nao funcionar, pode pegar o erro aqui

                var obj2 = content2.Content.ReadAsStringAsync();
                CNPJ myDeserializedClass = JsonConvert.DeserializeObject<CNPJ>(obj2.Result);
                fii.cnpj = myDeserializedClass.detailFund.cnpj;
            }
            return fiis;
        }        
    }
}
