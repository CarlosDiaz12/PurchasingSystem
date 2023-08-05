using System.Text.Json.Serialization;

namespace Application.External.DTOs
{
    public class CreateAccountingEntryResultDTO
    {
        [JsonPropertyName("exito")]
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
