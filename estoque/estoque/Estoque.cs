using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Estoque
    {
        public ObjectId _id { get; set; }
        public string Codigo { get; set; }
        public string ClasFiscal { get; set; }
        public string Setor { get; set; }
        public string CodAlf { get; set; }
        public string Versao { get; set; }
        public string PartNumber { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public string NF1 { get; set; }
        public string Fornecedor { get; set; }
        public DateTime dataCadastro { get; set; }
        public double valorNF { get; set; }

    }
}
