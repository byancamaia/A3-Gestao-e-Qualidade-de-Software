using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APICaminhoesCrude.Context
{

    [Table("Caminhoes")]
    public class Caminhao
    {
        [Key()]
        public int Id { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public MarcaModelo NomeModelo { get; set; }

    }

}
