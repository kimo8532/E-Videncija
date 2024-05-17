using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Table("radna_smjena_evidencija_radnika")]
public partial class RadnaSmjenaEvidencijaRadnika
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_radna_smjena_radnici")]
    public int IdRadnaSmjenaRadnici { get; set; }

    [Column("naslov_posla")]
    [StringLength(255)]
    public string NaslovPosla { get; set; } = null!;

    [Column("opis_posla", TypeName = "text")]
    public string OpisPosla { get; set; } = null!;

    [Column("pocetak_rada")]
    public TimeOnly PocetakRada { get; set; }

    [Column("zavrsetak_rada")]
    public TimeOnly ZavrsetakRada { get; set; }

    [Column("sati_zastoja")]
    public int SatiZastoja { get; set; }

    [Column("evidentirano")]
    [StringLength(255)]
    public string Evidentirano { get; set; } = null!;

    [ForeignKey("IdRadnaSmjenaRadnici")]
    [InverseProperty("RadnaSmjenaEvidencijaRadnikas")]
    public virtual RadnaSmjenaRadnici IdRadnaSmjenaRadniciNavigation { get; set; } = null!;
}
