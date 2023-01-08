using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace B3.DATA.Model
{
    public class ListarTodosFiisModel : ListarTodasAcoesModel
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
       

        public class DadosFii
        {
            [JsonPropertyName("segment")]
            public string segment { get; set; }

            [JsonPropertyName("acronym")]
            public string acronym { get; set; }

            [JsonPropertyName("fundName")]
            public string fundName { get; set; }

            [JsonPropertyName("companyName")]
            public string companyName { get; set; }

            [JsonPropertyName("cnpj")]
            public object cnpj { get; set; }
        }

        public class Fiis 
        {
            //[JsonPropertyName("page")]
            //public Page page { get; set; }

            [JsonPropertyName("results")]
            public List<DadosFii> results { get; set; }

        }

    }
}
