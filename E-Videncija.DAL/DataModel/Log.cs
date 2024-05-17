using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace E_Videncija.DAL.DataModel;

[Keyless]
[Table("logs")]
public partial class Log
{
    [Column("id")]
    public int Id { get; set; }

    [Column("action", TypeName = "text")]
    public string Action { get; set; } = null!;

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("time_of_action", TypeName = "datetime")]
    public DateTime TimeOfAction { get; set; }

    [Column("state")]
    [StringLength(255)]
    public string? State { get; set; }

    [Column("ip_address")]
    [StringLength(15)]
    public string? IpAddress { get; set; }
}
