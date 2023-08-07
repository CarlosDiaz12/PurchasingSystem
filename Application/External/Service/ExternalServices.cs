using Application.Common;
using Application.Common.Interfaces;
using Application.External.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Application.External.Service
{
    public class ExternalServices : IExternalServices
    {
        private readonly HttpClient _httpClient;
        public ExternalServices(IHttpClientFactory clientFactory) => _httpClient = clientFactory.CreateClient(Constants.ACCOUNTING_CLIENT_KEY);
        public async Task<CreateAccountingEntryResultDTO> CreateAccountingEntry(CreateAccountingEntryDTO dto)
        {
            var requestData = new CreateAccountingEntryExternalDTO
            {
                Descripcion = dto.Descripcion,
                Monto = dto.Monto,
                Auxiliar = Constants.AccountingEntry.PURCHASE_AUX_ID,
                CuentaCR = Constants.AccountingEntry.DEBIT_CREDIT_ACCOUNT_ID,
                CuentaDB = Constants.AccountingEntry.DEBIT_CREDIT_ACCOUNT_ID
            };

            var response = await _httpClient.PostAsJsonAsync("post-accounting-entries", requestData);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al guardar asiento contable");

            var data = await response.Content.ReadFromJsonAsync<CreateAccountingEntryResultDTO>();
            return data;
        }

        public async Task<GetAccountingEntriesDTO> GetAccountingEntries()
        {
            var response = await _httpClient.GetAsync($"get-accounting-entries/auxiliar={Constants.AccountingEntry.PURCHASE_AUX_ID}");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error al obtener asientos contables.");

            var data = await response.Content.ReadFromJsonAsync<GetAccountingEntriesDTO>();
            return data;
        }
    }
}
