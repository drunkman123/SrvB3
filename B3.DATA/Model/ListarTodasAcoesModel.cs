using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.DATA.Model
{
    public class ListarTodasAcoesModel
    {
        
    //public class Page
    //{
    //    public int pageNumber { get; set; }
    //    public int pageSize { get; set; }
    //    public int totalRecords { get; set; }
    //    public int totalPages { get; set; }
    //}

    public class DadosAcoes
    {
        public string codeCVM { get; set; }
        public string issuingCompany { get; set; }
        public string companyName { get; set; }
        public string tradingName { get; set; }
        public string cnpj { get; set; }
        public string marketIndicator { get; set; }
        public string typeBDR { get; set; }
        public string dateListing { get; set; }
        public string status { get; set; }
        public string segment { get; set; }
        public string segmentEng { get; set; }
        public string type { get; set; }
        public string market { get; set; }
    }

    public class Acoes
    {
        //public Page page { get; set; }
        public List<DadosAcoes> results { get; set; }
    }


    }
}
