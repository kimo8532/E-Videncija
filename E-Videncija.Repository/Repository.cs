using E_Videncija.DAL;
using E_Videncija.DAL.DataModel;
using E_Videncija.Model.UserInformation;
using E_Videncija.Repository.Automappers;
using E_Videncija.Repository.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace E_Videncija.Repository
{
    public class Repository : IRepository
    {
        private readonly EVidencijaDbContext dbContext;
        private IRepositoryMappingService _mapper;

        public Repository(EVidencijaDbContext appDbContext, IRepositoryMappingService mapper)
        {
            this.dbContext = appDbContext;
            _mapper = mapper;
        }
        public IEnumerable<UserInformationDTO> GetAllUsers()
        {
            IEnumerable<UserInformation> usersDb = dbContext.UserInformations.ToList();

            IEnumerable<UserInformationDTO> users = _mapper.Map<IEnumerable<UserInformationDTO>>(usersDb);
            return users;
        }

        public UserInformationDTO GetUserByUserId(int? userId)
        {
            UserInformation userDb = dbContext.UserInformations.Find(userId);

            UserInformationDTO user = _mapper.Map<UserInformationDTO>(userDb);

            return user;
        }
    }
}
