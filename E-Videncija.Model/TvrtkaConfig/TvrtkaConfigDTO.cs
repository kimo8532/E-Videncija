using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Videncija.Model.TvrtkaConfig
{
    public class TvrtkaConfigDTO
    {
        public bool ViseSmjenskiRad { get; set; }
        public bool AutomatskoRegistriranjeKorisnika { get; set; }
        public bool AutomatskiPosaljiEvidencijuKnjigovodi { get; set; }
        public bool AutomatskiEvidentirajRad { get; set; }
        public string ImeTvrtke { get; set; } = null!;
        public string AdresaTvrtke { get; set; } = null!;
        public string GradTvrtke { get; set; } = null!;
    }
}
