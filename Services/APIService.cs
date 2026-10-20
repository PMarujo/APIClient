using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using APIClient.Models;
using System.Net.Http.Json;

namespace APIClient.Services
{
    internal class APIService
    {
        private static readonly HttpClient _httpClient;

        static APIService()
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7259/api/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public static async Task <List<Aluno>> ObterAlunosAsync()
        {
            try
            {
                var alunos = await _httpClient.GetFromJsonAsync<List<Aluno>>("api/Alunos");
                return alunos ?? new List<Aluno>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro de conexão com a API: {ex.Message}");
            }
        }
    }
}
