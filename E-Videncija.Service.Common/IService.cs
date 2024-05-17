using E_Videncija.Model.UserInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Videncija.Service.Common
{
    public interface IService
    {
        IEnumerable<UserInformationDTO> GetAllUsers();
        UserInformationDTO GetUserByUserId(int? userId);
    }
}
