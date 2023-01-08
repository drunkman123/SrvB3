using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace B3.DATA.Model
{
    public class ListarCNPJFiisModel
    {
        // CNPJ myDeserializedClass = JsonSerializer.Deserialize<CNPJ>(myJsonResponse);
        public class DetailFund
        {
            [JsonPropertyName("acronym")]
            public string? acronym { get; set; }

            [JsonPropertyName("tradingName")]
            public string? tradingName { get; set; }

            [JsonPropertyName("tradingCode")]
            public string? tradingCode { get; set; }

            [JsonPropertyName("tradingCodeOthers")]
            public string? tradingCodeOthers { get; set; }

            [JsonPropertyName("cnpj")]
            public string? cnpj { get; set; }

            [JsonPropertyName("classification")]
            public string? classification { get; set; }

            [JsonPropertyName("webSite")]
            public string? webSite { get; set; }

            [JsonPropertyName("fundAddress")]
            public string? fundAddress { get; set; }

            [JsonPropertyName("fundPhoneNumberDDD")]
            public string? fundPhoneNumberDDD { get; set; }

            [JsonPropertyName("fundPhoneNumber")]
            public string? fundPhoneNumber { get; set; }

            [JsonPropertyName("fundPhoneNumberFax")]
            public string? fundPhoneNumberFax { get; set; }

            [JsonPropertyName("positionManager")]
            public string? positionManager { get; set; }

            [JsonPropertyName("managerName")]
            public string? managerName { get; set; }

            [JsonPropertyName("companyAddress")]
            public string? companyAddress { get; set; }

            [JsonPropertyName("companyPhoneNumberDDD")]
            public string? companyPhoneNumberDDD { get; set; }

            [JsonPropertyName("companyPhoneNumber")]
            public string? companyPhoneNumber { get; set; }

            [JsonPropertyName("companyPhoneNumberFax")]
            public string? companyPhoneNumberFax { get; set; }

            [JsonPropertyName("companyEmail")]
            public string? companyEmail { get; set; }

            [JsonPropertyName("companyName")]
            public string? companyName { get; set; }

            [JsonPropertyName("quotaCount")]
            public string? quotaCount { get; set; }

            [JsonPropertyName("quotaDateApproved")]
            public string? quotaDateApproved { get; set; }

            [JsonPropertyName("typeFNET")]
            public object? typeFNET { get; set; }

            [JsonPropertyName("codes")]
            public List<string>? codes { get; set; }

            [JsonPropertyName("codesOther")]
            public object? codesOther { get; set; }

            [JsonPropertyName("segment")]
            public object? segment { get; set; }
        }

        public class CNPJ
        {
            [JsonPropertyName("detailFund")]
            public DetailFund? detailFund { get; set; }

            [JsonPropertyName("shareHolder")]
            public ShareHolder? shareHolder { get; set; }
        }

        public class ShareHolder
        {
            [JsonPropertyName("shareHolderName")]
            public string? shareHolderName { get; set; }

            [JsonPropertyName("shareHolderAddress")]
            public string? shareHolderAddress { get; set; }

            [JsonPropertyName("shareHolderPhoneNumberDDD")]
            public string? shareHolderPhoneNumberDDD { get; set; }

            [JsonPropertyName("shareHolderPhoneNumber")]
            public string? shareHolderPhoneNumber { get; set; }

            [JsonPropertyName("shareHolderFaxNumber")]
            public string? shareHolderFaxNumber { get; set; }

            [JsonPropertyName("shareHolderEmail")]
            public string? shareHolderEmail { get; set; }
        }


    }
}
