using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.Models
{
    public class Alimento
    {
        public Alimento()
        {
            this.AlimentosConsumo = new List<AlimentoConsumo>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal QtdCarboidrato { get; set; }
        public virtual List<AlimentoConsumo> AlimentosConsumo { get; set; }
    }
}