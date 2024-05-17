using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Table("radna_smjena_dani")]
public partial class RadnaSmjenaDani
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_radna_smjena")]
    public int IdRadnaSmjena { get; set; }

    [Column("datum")]
    public DateOnly Datum { get; set; }

    [ForeignKey("IdRadnaSmjena")]
    [InverseProperty("RadnaSmjenaDanis")]
    public virtual RadnaSmjene IdRadnaSmjenaNavigation { get; set; } = null!;

    [InverseProperty("IdRadnaSmjenaDaniNavigation")]
    public virtual ICollection<RadnaSmjenaRadnici> RadnaSmjenaRadnicis { get; set; } = new List<RadnaSmjenaRadnici>();
}
