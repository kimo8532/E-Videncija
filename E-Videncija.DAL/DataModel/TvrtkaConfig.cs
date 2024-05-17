using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Keyless]
[Table("tvrtka_config")]
public partial class TvrtkaConfig
{
    [Column("vise_smjenski_rad")]
    public bool ViseSmjenskiRad { get; set; }

    [Column("automatsko_registriranje_korisnika")]
    public bool AutomatskoRegistriranjeKorisnika { get; set; }

    [Column("automatski_posalji_evidenciju_knjigovodi")]
    public bool AutomatskiPosaljiEvidencijuKnjigovodi { get; set; }

    [Column("ime_tvrtke")]
    [StringLength(255)]
    public string ImeTvrtke { get; set; } = null!;

    [Column("adresa_tvrtke")]
    [StringLength(255)]
    public string AdresaTvrtke { get; set; } = null!;

    [Column("grad_tvrtke")]
    [StringLength(255)]
    public string GradTvrtke { get; set; } = null!;
}
