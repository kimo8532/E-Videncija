using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Table("radnik_placa")]
public partial class RadnikPlaca
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_evidentiranog_mjeseca")]
    public int IdEvidentiranogMjeseca { get; set; }

    [Column("id_radnik")]
    public int IdRadnik { get; set; }

    [Column("je_placen")]
    public bool JePlacen { get; set; }

    [ForeignKey("IdEvidentiranogMjeseca")]
    [InverseProperty("RadnikPlacas")]
    public virtual EvidentiranMjesec IdEvidentiranogMjesecaNavigation { get; set; } = null!;

    [ForeignKey("IdRadnik")]
    [InverseProperty("RadnikPlacas")]
    public virtual UserInformation IdRadnikNavigation { get; set; } = null!;
}
