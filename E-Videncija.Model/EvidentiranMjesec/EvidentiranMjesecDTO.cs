using E_Videncija.DAL.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Videncija.Model.EvidentiranMjesec
{
    public class EvidentiranMjesecDTO
    {
        public int Id { get; set; }
        public DateOnly PocetakMjeseca { get; set; }
        public DateOnly ZavrsetakMjeseca { get; set; }
        public virtual ICollection<EvidentiranoVrijeme> EvidentiranoVrijemes { get; set; } = new List<EvidentiranoVrijeme>();
        public virtual ICollection<RadnikPlaca> RadnikPlacas { get; set; } = new List<RadnikPlaca>();
    }
}
