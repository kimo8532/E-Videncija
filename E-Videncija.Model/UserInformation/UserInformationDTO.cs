using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Videncija.DAL.DataModel;

namespace E_Videncija.Model.UserInformation
{
    public class UserInformationDTO
    {
        public int Id { get; set; }
        public string Ime { get; set; } = null!;
        public string Prezime { get; set; } = null!;
        public string? Password { get; set; }
        public DateOnly DatumRođenja { get; set; }
        public string Spol { get; set; } = null!;
        public string ProfilnaSlika { get; set; } = null!;

        public string TipUgovora { get; set; } = null!;
        public string Pozicija { get; set; } = null!;

        public string Odjel { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<RadnaSmjenaRadnici> RadnaSmjenaRadnicis { get; set; } = new List<RadnaSmjenaRadnici>();

        public virtual ICollection<RadnikPlaca> RadnikPlacas { get; set; } = new List<RadnikPlaca>();
    }
}
