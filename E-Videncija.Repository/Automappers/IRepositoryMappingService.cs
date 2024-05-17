using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Videncija.Repository.Automappers
{
    public interface IRepositoryMappingService
    {
        TDestination Map<TDestination>(object source);
    }
}
