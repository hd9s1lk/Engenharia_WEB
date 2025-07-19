using System.ComponentModel.DataAnnotations;

namespace REC_22.Models
{
    public class EmpresaPaisViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Abreviatura { get; set; }
        public int NumEmpresas { get; set; }

    }
}
