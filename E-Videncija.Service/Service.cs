using E_Videncija.Model.UserInformation;
using E_Videncija.Repository.Common;
using E_Videncija.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Videncija.Service
{
    public class Service : IService
    {
        IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserInformationDTO> GetAllUsers()
        {
            IEnumerable<UserInformationDTO> userDb = _repository.GetAllUsers();
            return userDb;
        }

        public UserInformationDTO GetUserByUserId(int? userId)
        {
            return _repository.GetUserByUserId(userId);

        }
    }
}
