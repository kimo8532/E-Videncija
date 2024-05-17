using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Table("evidentiran_mjesec")]
public partial class EvidentiranMjesec
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("pocetak_mjeseca")]
    public DateOnly PocetakMjeseca { get; set; }

    [Column("zavrsetak_mjeseca")]
    public DateOnly ZavrsetakMjeseca { get; set; }

    [InverseProperty("EvidentiranMjesec")]
    public virtual ICollection<EvidentiranoVrijeme> EvidentiranoVrijemes { get; set; } = new List<EvidentiranoVrijeme>();

    [InverseProperty("IdEvidentiranogMjesecaNavigation")]
    public virtual ICollection<RadnikPlaca> RadnikPlacas { get; set; } = new List<RadnikPlaca>();
}
