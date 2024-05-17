using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Table("radna_smjena_radnici")]
public partial class RadnaSmjenaRadnici
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("id_user_information")]
    public int IdUserInformation { get; set; }

    [Column("id_radna_smjena_dani")]
    public int IdRadnaSmjenaDani { get; set; }

    [ForeignKey("IdRadnaSmjenaDani")]
    [InverseProperty("RadnaSmjenaRadnicis")]
    public virtual RadnaSmjenaDani IdRadnaSmjenaDaniNavigation { get; set; } = null!;

    [ForeignKey("IdUserInformation")]
    [InverseProperty("RadnaSmjenaRadnicis")]
    public virtual UserInformation IdUserInformationNavigation { get; set; } = null!;

    [InverseProperty("IdRadnaSmjenaRadniciNavigation")]
    public virtual ICollection<RadnaSmjenaEvidencijaRadnika> RadnaSmjenaEvidencijaRadnikas { get; set; } = new List<RadnaSmjenaEvidencijaRadnika>();
}
