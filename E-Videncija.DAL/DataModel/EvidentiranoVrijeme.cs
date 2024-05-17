using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Table("evidentirano_vrijeme")]
public partial class EvidentiranoVrijeme
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("datum")]
    public DateOnly Datum { get; set; }

    [Column("pocetak_rada")]
    public TimeOnly PocetakRada { get; set; }

    [Column("zavrsetak_rada")]
    public TimeOnly ZavrsetakRada { get; set; }

    [Column("sati_zastoja_od")]
    public TimeOnly? SatiZastojaOd { get; set; }

    [Column("sati_zastoja_do")]
    public TimeOnly? SatiZastojaDo { get; set; }

    [Column("opis")]
    [StringLength(255)]
    public string Opis { get; set; } = null!;

    [Column("evidentiran_mjesec_id")]
    public int? EvidentiranMjesecId { get; set; }

    [ForeignKey("EvidentiranMjesecId")]
    [InverseProperty("EvidentiranoVrijemes")]
    public virtual EvidentiranMjesec? EvidentiranMjesec { get; set; }
}
