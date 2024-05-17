using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Table("radna_smjene")]
public partial class RadnaSmjene
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("start_time")]
    public TimeOnly StartTime { get; set; }

    [Column("end_time")]
    public TimeOnly EndTime { get; set; }

    [Column("posebni_dan")]
    public bool? PosebniDan { get; set; }

    [Column("datum_za_posebni_dan")]
    public DateOnly? DatumZaPosebniDan { get; set; }

    [InverseProperty("IdRadnaSmjenaNavigation")]
    public virtual ICollection<RadnaSmjenaDani> RadnaSmjenaDanis { get; set; } = new List<RadnaSmjenaDani>();
}
