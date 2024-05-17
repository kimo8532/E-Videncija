using E_Videncija.Model.UserInformation;

namespace E_Videncija.Repository.Common
{
    public interface IRepository
    {
        IEnumerable<UserInformationDTO> GetAllUsers();
        UserInformationDTO GetUserByUserId(int? userId);
    }
}
