using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Table("user_information")]
[Index("Email", Name = "UQ__user_inf__AB6E6164E3AD7D39", IsUnique = true)]
public partial class UserInformation
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ime")]
    [StringLength(255)]
    public string Ime { get; set; } = null!;

    [Column("prezime")]
    [StringLength(255)]
    public string Prezime { get; set; } = null!;

    [Column("datum_rođenja")]
    public DateOnly DatumRođenja { get; set; }

    [Column("spol")]
    [StringLength(1)]
    [Unicode(false)]
    public string Spol { get; set; } = null!;

    [Column("profilna_slika")]
    [StringLength(255)]
    public string ProfilnaSlika { get; set; } = null!;

    [Column("tip_ugovora")]
    [StringLength(255)]
    public string TipUgovora { get; set; } = null!;

    [Column("pozicija")]
    [StringLength(255)]
    public string Pozicija { get; set; } = null!;

    [Column("odjel")]
    [StringLength(255)]
    public string Odjel { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    public string? Password { get; set; }

    [Column("role")]
    [StringLength(255)]
    public string Role { get; set; } = null!;

    [Column("vrijeme_izrada_racuna", TypeName = "datetime")]
    public DateTime VrijemeIzradaRacuna { get; set; }

    [InverseProperty("IdUserInformationNavigation")]
    public virtual ICollection<RadnaSmjenaRadnici> RadnaSmjenaRadnicis { get; set; } = new List<RadnaSmjenaRadnici>();

    [InverseProperty("IdRadnikNavigation")]
    public virtual ICollection<RadnikPlaca> RadnikPlacas { get; set; } = new List<RadnikPlaca>();
}
